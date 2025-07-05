using System.Data;
using librarian.Data;
using librarian.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScottPlot;

namespace librarian.Forms
{
    public partial class ReaderMainForm : BaseForm
    {
        private readonly int _userId;

        private int? _selectedRentalId = null;

        private int? _selectedBookId = null;

        private BaseForm _loginForm;

        public ReaderMainForm(int userId, BaseForm loginForm)
        {
            InitializeComponent();

            this.Text = "Librarian";

            _userId = userId;
            _loginForm = loginForm;

            LoadAllRequiredData();

            AddVisibleChanged();
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
            LoadMyRentals();
            LoadRentalsHistory();
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedTab == mainTabControl.TabPages["booksTabPage"])
            {
                LoadBooks();
                _selectedBookId = null;
            }
            if (mainTabControl.SelectedTab == mainTabControl.TabPages["myRentalsTabPage"])
            {
                LoadMyRentals();
                _selectedRentalId = null;
            }
            if (mainTabControl.SelectedTab == mainTabControl.TabPages["accountTabPage"])
            {
                LoadUserData();
            }
            if (mainTabControl.SelectedTab == mainTabControl.TabPages["rentalsHistoryTabPage"])
            {
                LoadRentalsHistory();
            }
            if (mainTabControl.SelectedTab == mainTabControl.TabPages["statisticsTabPage"])
            {
                startDatePicker.Value = DateTime.Today;
                endDatePicker.Value = DateTime.Today;

                formsPlot.Plot.Clear();
                formsPlot.Refresh();

                totalRentalsLabel.Text = "Total Rentals: 0";
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

        private void LoadMyRentals()
        {
            using (var db = new LibraryDbContext())
            {
                var rentals = new SortableBindingList<MyRentalDisplayDto>(
                    db.ActiveRentalViews
                        .Where(r => r.ReaderId == _userId)
                        .Select(r => new MyRentalDisplayDto
                        {
                            RentalId = r.RentalId,
                            BookTitle = r.BookTitle,
                            RentalDate = r.RentalDate,
                            PlannedReturnDate = r.PlannedReturnDate
                        })
                        .ToList()
                );

                myRentalsDataGridView.DataSource = rentals;

                myRentalsDataGridView.Columns["RentalId"].Visible = false;
                myRentalsDataGridView.Columns["RentalDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                myRentalsDataGridView.Columns["PlannedReturnDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

                foreach (DataGridViewColumn col in myRentalsDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
        }

        private void LoadRentalsHistory()
        {
            using (var db = new LibraryDbContext())
            {
                var rentals = new SortableBindingList<RentalHistoryDisplayDto>(
                    db.Rentals
                        .Include(r => r.Book)
                        .Include(r => r.Reader)
                        .Where(r => r.ReaderId == _userId && r.ReturnDate != null)
                        .Select(r => new RentalHistoryDisplayDto
                        {
                            RentalId = r.RentalId,
                            BookTitle = r.Book.Title,
                            RentalDate = r.RentalDate,
                            PlannedReturnDate = r.PlannedReturnDate,
                            ReturnDate = r.ReturnDate.Value
                        })
                        .ToList());

                rentalsHistoryDataGridView.DataSource = rentals;

                rentalsHistoryDataGridView.Columns["RentalId"].Visible = false;

                rentalsHistoryDataGridView.Columns["RentalDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                rentalsHistoryDataGridView.Columns["PlannedReturnDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                rentalsHistoryDataGridView.Columns["ReturnDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

                foreach (DataGridViewColumn col in rentalsHistoryDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
        }

        private void LoadUserData()
        {
            using (var db = new LibraryDbContext())
            {
                var reader = db.Readers.Include(r => r.UserCredentials)
                                       .FirstOrDefault(r => r.UserCredentials.ReaderId == _userId);
                if (reader != null)
                {
                    welcomeLabel.Text = $"Welcome, {reader.FullName}!";

                    fullNameLabel.Text = $"Full name: {reader.FullName}";
                    emailLabel.Text = $"Email: {reader.Email}";
                    phoneNumberLabel.Text = $"Phone number: {reader.PhoneNumber}";
                    birthdateLabel.Text = $"Birthdate: {reader.DateOfBirth.ToShortDateString()}";

                    if (reader.Photo != null)
                    {
                        using (var ms = new MemoryStream(reader.Photo))
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
            _loginForm.Show();
            this.Hide();
        }

        private void rentalsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = myRentalsDataGridView.Rows[e.RowIndex];
                _selectedRentalId = Convert.ToInt32(row.Cells["RentalId"].Value);
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

        private void endRentalButton_Click(object sender, EventArgs e)
        {
            if (_selectedRentalId == null)
            {
                MessageBox.Show("Please select a rental to end.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to end this rental?", "Confirm End Rental", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return;
            }

            using (var context = new LibraryDbContext())
            {
                var rental = context.Rentals
                                    .Include(r => r.Book)
                                    .FirstOrDefault(r => r.RentalId == _selectedRentalId);

                if (rental == null)
                {
                    MessageBox.Show("Rental not found.");
                    return;
                }

                if (rental.ReturnDate != null)
                {
                    MessageBox.Show("This rental is already ended.");
                    return;
                }

                try
                {
                    using (var conn = new SqlConnection(context.Database.GetConnectionString()))
                    {
                        conn.Open();

                        using (var cmd = new SqlCommand("EndRentalProcedure", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@RentalId", _selectedRentalId.Value);
                            cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);

                            cmd.ExecuteNonQuery();
                        }

                        conn.Close();
                    }

                    MessageBox.Show("Rental successfully ended.");
                    LoadMyRentals();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error while ending rental: " + ex.Message);
                }
            }
        }

        private bool IsOnBlackList()
        {
            using (var db = new LibraryDbContext())
            {
                return db.BlacklistedReaders.Any(b => b.ReaderId == _userId);
            }
        }

        private void rentBookButton_Click(object sender, EventArgs e)
        {
            if (IsOnBlackList())
            {
                MessageBox.Show("You are on blacklist and cannot rent a book.");
                return;
            }

            if (_selectedBookId == null)
            {
                MessageBox.Show("Please select a book to rent.");
                return;
            }

            var popup = new PlannedReturnDateForm();
            if (popup.ShowDialog() != DialogResult.OK)
                return;

            var plannedReturnDate = popup.PlannedReturnDate;

            if (plannedReturnDate <= DateTime.Today)
            {
                MessageBox.Show("Planned return date must be in the future.");
                return;
            }

            using (var context = new LibraryDbContext())
            {
                var book = context.Books.FirstOrDefault(b => b.BookId == _selectedBookId);
                if (book == null)
                {
                    MessageBox.Show("Book not found in the database.");
                    return;
                }

                try
                {
                    using (var conn = new SqlConnection(context.Database.GetConnectionString()))
                    {
                        conn.Open();

                        using (var cmd = new SqlCommand("RentBookProcedure", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@BookId", _selectedBookId);
                            cmd.Parameters.AddWithValue("@ReaderId", _userId);
                            cmd.Parameters.AddWithValue("@RentalDate", DateTime.Today);
                            cmd.Parameters.AddWithValue("@PlannedReturnDate", plannedReturnDate.Value);

                            cmd.ExecuteNonQuery();
                        }

                        conn.Close();
                    }

                    MessageBox.Show($"Book \"{book.Title}\" has been rented until {plannedReturnDate.Value.ToShortDateString()}.");
                    LoadBooks(); // Refresh book list
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Failed to rent book: {ex.Message}");
                }
            }
        }

        private void loadStatisticsButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = startDatePicker.Value.Date;
            DateTime endDate = endDatePicker.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Start date must be before end date.");
                return;
            }

            using (var db = new LibraryDbContext())
            {
                var rentals = db.Rentals
                    .Where(r => r.ReaderId == _userId &&
                                r.RentalDate >= startDate &&
                                r.RentalDate <= endDate)
                    .ToList();

                if (rentals.Count == 0)
                {
                    MessageBox.Show("No rentals found in the selected date range.");
                    formsPlot.Plot.Clear();
                    formsPlot.Refresh();
                    totalRentalsLabel.Text = "Total Rentals: 0";
                    return;
                }

                var grouped = rentals
                    .GroupBy(r => r.RentalDate.Date)
                    .ToDictionary(g => g.Key, g => g.Count());

                var allDates = Enumerable.Range(0, (endDate - startDate).Days + 1)
                    .Select(offset => startDate.AddDays(offset))
                    .ToList();

                double[] xDates = allDates.Select(d => d.ToOADate()).ToArray();
                double[] yCounts = allDates.Select(d => grouped.ContainsKey(d) ? grouped[d] : 0).Select(c => (double)c).ToArray();

                var plt = formsPlot.Plot;
                plt.Clear();
                plt.Add.Scatter(xDates, yCounts);
                plt.Axes.DateTimeTicksBottom();
                plt.Axes.Left.Label.Text = "Number of Rentals";
                plt.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericFixedInterval(1);
                plt.Axes.Bottom.Label.Text = "Date";
                plt.Title("My Rentals Over Time");

                formsPlot.Refresh();

                totalRentalsLabel.Text = $"Total Rentals: {rentals.Count}";
            }
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
                            var reader = db.Readers.FirstOrDefault(e => e.ReaderId == _userId);

                            if (reader != null)
                            {
                                reader.Photo = imageBytes;
                                db.SaveChanges();
                                MessageBox.Show("Photo updated.");
                                LoadUserData();

                                removePhotoButton.Visible = true;
                                editPhotoButton.Text = "Edit photo";
                            }
                            else
                            {
                                MessageBox.Show("Reader not found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during uploading photo: " + ex.Message);
                    }
                }
            }
        }

        private void removePhotoButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            using (var db = new LibraryDbContext())
            {
                var reader = db.Readers
                                 .Include(e => e.UserCredentials)
                                 .FirstOrDefault(e => e.UserCredentials.ReaderId == _userId);

                if (reader != null)
                {
                    reader.Photo = null;
                    db.SaveChanges();

                    photoBox.Image = null;
                    MessageBox.Show("Photo has been deleted successfully.");

                    removePhotoButton.Visible = false;
                    editPhotoButton.Text = "Add photo";
                }
                else
                {
                    MessageBox.Show("Reader not found.");
                }
            }
        }
    }
}