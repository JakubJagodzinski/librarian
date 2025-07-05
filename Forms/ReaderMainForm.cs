using librarian.Data;
using librarian.Models;
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
                var books = db.Books
                    .Include(b => b.Author)
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        Author = b.Author.AuthorFullName,
                        b.PublishedYear,
                        b.Pages,
                        b.InStock
                    }).ToList();

                booksDataGridView.DataSource = books;
                booksDataGridView.Columns["BookId"].Visible = false;
            }
        }

        private void LoadMyRentals()
        {
            using (var db = new LibraryDbContext())
            {
                var rentals = db.Rentals
                    .Include(r => r.Book)
                    .Include(r => r.Reader)
                    .Where(r => r.ReaderId == _userId && r.ReturnDate == null)
                    .Select(r => new
                    {
                        r.RentalId,
                        r.Book.Title,
                        RentalDate = r.RentalDate.ToShortDateString(),
                        PlannedReturnDate = r.PlannedReturnDate.ToShortDateString()
                    })
                    .ToList();

                myRentalsDataGridView.DataSource = rentals;
                myRentalsDataGridView.Columns["RentalId"].Visible = false;
            }
        }

        private void LoadRentalsHistory()
        {
            using (var db = new LibraryDbContext())
            {
                var rentals = db.Rentals
                    .Include(r => r.Book)
                    .Include(r => r.Reader)
                    .Where(r => r.ReaderId == _userId && r.ReturnDate != null)
                    .Select(r => new
                    {
                        r.RentalId,
                        r.Book.Title,
                        RentalDate = r.RentalDate.ToShortDateString(),
                        PlannedReturnDate = r.PlannedReturnDate.ToShortDateString(),
                        ReturnDate = r.ReturnDate.Value.ToShortDateString()
                    })
                    .ToList();

                rentalsHistoryDataGridView.DataSource = rentals;
                rentalsHistoryDataGridView.Columns["RentalId"].Visible = false;
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
                    welcomeLabel.Text = $"Welcome, {reader.FullName}";

                    fullNameLabel.Text = $"Full name: {reader.FullName}";
                    emailLabel.Text = $"Email: {reader.Email}";
                    phoneNumberLabel.Text = $"Phone number: {reader.PhoneNumber}";
                    birthdateLabel.Text = $"Birthdate: {reader.DateOfBirth.ToShortDateString()}";
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

            using (var db = new LibraryDbContext())
            {
                var rental = db.Rentals
                               .Include(r => r.Book)
                               .FirstOrDefault(r => r.RentalId == _selectedRentalId);

                if (rental != null)
                {
                    if (rental.ReturnDate != null)
                    {
                        MessageBox.Show("This rental is already ended.");
                        return;
                    }

                    rental.ReturnDate = DateTime.Now;
                    rental.Book.InStock += 1;

                    db.SaveChanges();

                    MessageBox.Show("Rental successfully ended.");

                    LoadMyRentals();
                }
                else
                {
                    MessageBox.Show("Rental not found.");
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

            using (var db = new LibraryDbContext())
            {
                var book = db.Books.FirstOrDefault(b => b.BookId == _selectedBookId);

                if (book == null)
                {
                    MessageBox.Show("Book not found in the database.");
                    return;
                }

                if (book.InStock <= 0)
                {
                    MessageBox.Show("This book is currently out of stock.");
                    return;
                }

                var popup = new PlannedReturnDateForm();
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    var plannedReturnDate = popup.PlannedReturnDate;

                    if (plannedReturnDate <= DateTime.Today)
                    {
                        MessageBox.Show("Planned return date must be in the future.");
                        return;
                    }

                    var rental = new Rental
                    {
                        BookId = book.BookId,
                        ReaderId = _userId,
                        RentalDate = DateTime.Today,
                        PlannedReturnDate = plannedReturnDate.Value,
                        ReturnDate = null
                    };

                    db.Rentals.Add(rental);
                    book.InStock -= 1;
                    db.SaveChanges();

                    MessageBox.Show($"Book \"{book.Title}\" has been rented until {plannedReturnDate.Value.ToShortDateString()}.");

                    LoadBooks();
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


    }
}