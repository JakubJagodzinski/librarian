using System;
using librarian.Data;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class ReaderMainForm : BaseForm
    {
        private readonly int _userId;

        public ReaderMainForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            LoadUserData();
            LoadBooks();
            LoadRentals();

            this.Text = "Librarian";
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
            var loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            loginForm.Show();
            this.Hide();
        }

    }
}
