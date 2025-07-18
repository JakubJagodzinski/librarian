﻿using librarian.Data;
using librarian.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class EmployeeMainForm : BaseForm
    {

        private readonly int _userId;

        private int? _selectedReaderId = null;

        private int? _selectedBlacklistEntryId = null;

        private int? _selectedBookId = null;

        private BaseForm _loginForm;

        public EmployeeMainForm(int userId, BaseForm loginForm)
        {
            InitializeComponent();

            this.Text = "Librarian";

            _userId = userId;

            LoadAllRequiredData();

            AddVisibleChanged();

            _loginForm = loginForm;
        }

        private void AddVisibleChanged()
        {
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible)
                {
                    LoadAllRequiredData();
                }
            };
        }

        private void LoadAllRequiredData()
        {
            LoadUserData();
            LoadBooks();
            LoadReaders();
            LoadBlacklistedReaders();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["blacklistedReadersTabPage"])
            {
                LoadBlacklistedReaders();
                _selectedBlacklistEntryId = null;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["readersTabPage"])
            {
                LoadReaders();
                _selectedReaderId = null;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["booksTabPage"])
            {
                LoadBooks();
                _selectedBookId = null;
            }
        }

        private void LoadBlacklistedReaders()
        {
            using (var db = new LibraryDbContext())
            {
                var blacklistedReaders = new SortableBindingList<BlacklistedReaderDisplayDto>(
                    db.BlacklistedReaders
                        .Include(b => b.Reader)
                        .Where(b => b.RemovalDate == null || b.RemovalDate > DateTime.Now)
                        .Select(b => new BlacklistedReaderDisplayDto
                        {
                            BlacklistedReaderId = b.BlacklistedReaderId,
                            ReaderName = b.Reader.FullName ?? "",
                            Reason = b.Reason ?? "",
                            BlacklistedDate = b.BlacklistedDate
                        })
                        .ToList());

                blacklistedReadersDataGridView.DataSource = blacklistedReaders;

                blacklistedReadersDataGridView.Columns["BlacklistedDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

                foreach (DataGridViewColumn col in blacklistedReadersDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
        }

        private void LoadReaders()
        {
            using (var db = new LibraryDbContext())
            {
                var readers = new SortableBindingList<ReaderDisplayDto>(db.Readers
                    .Select(r => new ReaderDisplayDto
                    {
                        ReaderId = r.ReaderId,
                        FullName = r.FullName ?? "",
                        Email = r.Email ?? "",
                        PhoneNumber = r.PhoneNumber ?? "",
                        DateOfBirth = r.DateOfBirth
                    }).ToList());

                readersDataGridView.DataSource = readers;

                readersDataGridView.Columns["DateOfBirth"].DefaultCellStyle.Format = "dd.MM.yyyy";

                foreach (DataGridViewColumn col in readersDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
        }

        private void LoadBooks()
        {
            using (var db = new LibraryDbContext())
            {
                var booksRaw = db.Books
                    .Include(b => b.Author)
                    .Include(b => b.BookGenres)
                        .ThenInclude(bg => bg.Genre)
                    .ToList();

                var books = new SortableBindingList<BookDisplayDto>(
                    booksRaw.Select(b => new BookDisplayDto
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author?.AuthorFullName ?? "",
                        PublishedYear = b.PublishedYear,
                        Pages = b.Pages,
                        InStock = b.InStock,
                        Genres = string.Join(", ", b.BookGenres
                            .Where(bg => bg.Genre != null)
                            .Select(bg => bg.Genre.GenreName)),
                        CurrentlyRented = GetActiveRentalCount(db, b.BookId)
                    }).ToList()
                );

                booksDataGridView.DataSource = books;

                foreach (DataGridViewColumn col in booksDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                booksDataGridView.CellFormatting -= booksDataGridView_CellFormatting;
                booksDataGridView.CellFormatting += booksDataGridView_CellFormatting;
            }
        }

        private int GetActiveRentalCount(LibraryDbContext context, int bookId)
        {
            using var conn = new SqlConnection(context.Database.GetConnectionString());
            conn.Open();

            using var cmd = new SqlCommand("SELECT dbo.GetActiveRentalsCount(@BookId)", conn);
            cmd.Parameters.AddWithValue("@BookId", bookId);

            return (int)(cmd.ExecuteScalar() ?? 0);
        }

        private void booksDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (booksDataGridView.Columns[e.ColumnIndex].Name == "Genres" && e.Value != null)
            {
                var genreList = e.Value.ToString()
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(g => g.Trim())
                    .Where(g => !string.IsNullOrWhiteSpace(g))
                    .ToList();

                e.Value = string.Join(", ", genreList);

                booksDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = string.Join("\n", genreList);
            }
        }

        private void LoadUserData()
        {
            using (var db = new LibraryDbContext())
            {
                var employee = db.Employees.Include(r => r.UserCredentials)
                                       .FirstOrDefault(r => r.UserCredentials.EmployeeId == _userId);
                if (employee != null)
                {
                    welcomeLabel.Text = $"Welcome, {employee.FullName}!";

                    fullNameLabel.Text = $"Full name: {employee.FullName}";
                    emailLabel.Text = $"Email: {employee.Email}";
                    phoneNumberLabel.Text = $"Phone number: {employee.PhoneNumber}";
                    hireDateLabel.Text = $"Hire date: {employee.HireDate.ToShortDateString()}";

                    if (employee.Photo != null)
                    {
                        using (var ms = new MemoryStream(employee.Photo))
                        {
                            photoBox.Image = System.Drawing.Image.FromStream(ms);
                        }

                        editPhotoButton.Text = "Edit photo";
                        removePhotoButton.Visible = true;
                    }
                    else
                    {
                        photoBox.Image = null;

                        editPhotoButton.Text = "Add photo";
                        removePhotoButton.Visible = false;
                    }
                }
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _loginForm.StartPosition = FormStartPosition.Manual;
            _loginForm.Location = this.Location;
            _loginForm.Show();
            this.Hide();
        }

        private void readersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = readersDataGridView.Rows[e.RowIndex];
                _selectedReaderId = Convert.ToInt32(row.Cells["ReaderId"].Value);
            }
        }

        private void blacklistedReadersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = blacklistedReadersDataGridView.Rows[e.RowIndex];
                _selectedBlacklistEntryId = Convert.ToInt32(row.Cells["BlacklistedReaderId"].Value);
            }
        }

        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = booksDataGridView.Rows[e.RowIndex];
                _selectedBookId = Convert.ToInt32(row.Cells["BookId"].Value);
            }
        }

        private void blacklistReaderButton_Click(object sender, EventArgs e)
        {
            if (_selectedReaderId == null)
            {
                MessageBox.Show(this, "You have to select reader you want to blacklist.");
                return;
            }

            var blacklistReaderForm = new BlacklistReaderForm(_selectedReaderId.Value, this);
            blacklistReaderForm.StartPosition = FormStartPosition.Manual;
            blacklistReaderForm.Location = this.Location;
            blacklistReaderForm.Show();
            this.Hide();
        }

        private void removeFromBlacklistButton_Click(object sender, EventArgs e)
        {
            if (_selectedBlacklistEntryId == null)
            {
                MessageBox.Show(this, "Please select a blacklisted reader entry to remove.");
                return;
            }

            using (var db = new LibraryDbContext())
            {
                var entry = db.BlacklistedReaders.FirstOrDefault(b => b.BlacklistedReaderId == _selectedBlacklistEntryId);

                if (entry != null)
                {
                    db.BlacklistedReaders.Remove(entry);
                    db.SaveChanges();

                    MessageBox.Show(this, "Blacklisted reader entry removed.");

                    LoadBlacklistedReaders();
                }
                else
                {
                    MessageBox.Show(this, "Could not find the blacklist entry in the database.");
                }
            }
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            var addBookForm = new AddBookForm(this);
            addBookForm.StartPosition = FormStartPosition.Manual;
            addBookForm.Location = this.Location;
            addBookForm.Show();
            this.Hide();
        }

        private void editBookButton_Click(object sender, EventArgs e)
        {
            if (_selectedBookId == null)
            {
                MessageBox.Show(this, "Select a book to edit.");
                return;
            }

            var editBookForm = new EditBookForm(this, _selectedBookId.Value);
            editBookForm.StartPosition = FormStartPosition.Manual;
            editBookForm.Location = this.Location;
            editBookForm.Show();
            this.Hide();
        }

        private void editPhotoButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose a photo";
                openFileDialog.Filter = "Graphic files(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(filePath);

                        using (var db = new LibraryDbContext())
                        {
                            var employee = db.Employees.FirstOrDefault(e => e.EmployeeId == _userId);

                            if (employee != null)
                            {
                                employee.Photo = imageBytes;
                                db.SaveChanges();
                                MessageBox.Show(this, "Photo updated.");
                                LoadUserData();

                                removePhotoButton.Visible = true;
                                editPhotoButton.Text = "Edit photo";
                            }
                            else
                            {
                                MessageBox.Show(this, "Employee not found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Error during uploading photo: " + ex.Message);
                    }
                }
            }
        }

        private void removePhotoButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(this, "Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            using (var db = new LibraryDbContext())
            {
                var employee = db.Employees
                                 .Include(e => e.UserCredentials)
                                 .FirstOrDefault(e => e.UserCredentials.EmployeeId == _userId);

                if (employee != null)
                {
                    employee.Photo = null;
                    db.SaveChanges();

                    photoBox.Image = null;
                    MessageBox.Show(this, "Photo has been deleted successfully.");

                    removePhotoButton.Visible = false;
                    editPhotoButton.Text = "Add photo";
                }
                else
                {
                    MessageBox.Show(this, "Employee not found.");
                }
            }
        }
    }
}
