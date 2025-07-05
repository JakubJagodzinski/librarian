using librarian.Data;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class ReaderMainForm : BaseForm
    {
        private readonly int _userId;

        private BaseForm _loginForm;

        public ReaderMainForm(int userId, BaseForm loginForm)
        {
            InitializeComponent();

            this.Text = "Librarian";

            _userId = userId;
            _loginForm = loginForm;

            LoadUserData();
            LoadBooks();
            LoadRentals();
        }

        private void LoadBooks()
        {
            using (var db = new LibraryDbContext())
            {
                var books = db.Books
                    .Include(b => b.Author)
                    .ToList();

                booksDataGridView.DataSource = books
                    .Select(b => new
                    {
                        b.Title,
                        Author = b.Author?.AuthorFullName ?? "",
                        b.PublishedYear,
                        b.Pages,
                        b.InStock
                    }).ToList();
            }
        }

        private void LoadRentals()
        {
            using (var db = new LibraryDbContext())
            {
                var rentals = db.Rentals
                    .Include(r => r.Book)
                    .Include(r => r.Reader)
                    .Where(r => r.ReaderId == _userId)
                    .Select(r => new
                    {
                        ID = r.RentalId,
                        Title = r.Book.Title,
                        RentalDate = r.RentalDate.ToShortDateString(),
                        ReturnDate = r.ReturnDate.HasValue ? r.ReturnDate.Value.ToShortDateString() : "–"
                    })
                    .ToList();

                myRentalsDataGridView.DataSource = rentals;
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

    }
}
