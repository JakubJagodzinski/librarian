using librarian.Data;
using librarian.Dto;
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
                var books = new SortableBindingList<BookDisplayDto>(db.Books
                    .Include(b => b.Author)
                    .Select(b => new BookDisplayDto
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        Author = b.Author.AuthorFullName ?? "",
                        PublishedYear = b.PublishedYear,
                        Pages = b.Pages,
                        InStock = b.InStock
                    }).ToList());

                booksDataGridView.DataSource = books;

                foreach (DataGridViewColumn col in booksDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
        }

        private void LoadUserData()
        {
            using (var db = new LibraryDbContext())
            {
                var reader = db.Employees.Include(r => r.UserCredentials)
                                       .FirstOrDefault(r => r.UserCredentials.EmployeeId == _userId);
                if (reader != null)
                {
                    welcomeLabel.Text = $"Welcome, {reader.FullName}!";

                    fullNameLabel.Text = $"Full name: {reader.FullName}";
                    emailLabel.Text = $"Email: {reader.Email}";
                    phoneNumberLabel.Text = $"Phone number: {reader.PhoneNumber}";
                    hireDateLabel.Text = $"Hire date: {reader.HireDate.ToShortDateString()}";
                }
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Hide();
        }

        private void readersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = readersDataGridView.Rows[e.RowIndex];
                _selectedReaderId = Convert.ToInt32(row.Cells["ReaderId"].Value);

                //MessageBox.Show($"Selected ReaderId: {selectedReaderId}");
            }
        }

        private void blacklistedReadersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = blacklistedReadersDataGridView.Rows[e.RowIndex];
                _selectedBlacklistEntryId = Convert.ToInt32(row.Cells["BlacklistedReaderId"].Value);

                //MessageBox.Show($"Selected BlacklistEntryId: {selectedBlacklistEntryId}");
            }
        }

        private void booksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = booksDataGridView.Rows[e.RowIndex];
                _selectedBookId = Convert.ToInt32(row.Cells["BookId"].Value);

                //MessageBox.Show($"Selected BookId: {selectedBookId}");
            }
        }

        private void blacklistReaderButton_Click(object sender, EventArgs e)
        {
            if (_selectedReaderId == null)
            {
                MessageBox.Show("You have to select reader you want to blacklist.");
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
                MessageBox.Show("Please select a blacklisted reader entry to remove.");
                return;
            }

            using (var db = new LibraryDbContext())
            {
                var entry = db.BlacklistedReaders.FirstOrDefault(b => b.BlacklistedReaderId == _selectedBlacklistEntryId);

                if (entry != null)
                {
                    db.BlacklistedReaders.Remove(entry);
                    db.SaveChanges();

                    MessageBox.Show("Blacklisted reader entry removed.");

                    LoadBlacklistedReaders();
                }
                else
                {
                    MessageBox.Show("Could not find the blacklist entry in the database.");
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
                MessageBox.Show("Select a book to edit.");
                return;
            }

            var editBookForm = new EditBookForm(this, _selectedBookId.Value);
            editBookForm.StartPosition = FormStartPosition.Manual;
            editBookForm.Location = this.Location;
            editBookForm.Show();
            this.Hide();
        }
    }
}
