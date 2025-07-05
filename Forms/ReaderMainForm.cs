using librarian.Data;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class ReaderMainForm : BaseForm
    {
        private readonly int _userId;

        private int? _selectedRentalId = null;

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

                //MessageBox.Show($"Selected RentalId: {selectedRentalId}");
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
    }
}