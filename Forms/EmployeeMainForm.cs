using librarian.Data;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class EmployeeMainForm : Form
    {

        private readonly int _userId;

        public EmployeeMainForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            LoadUserData();
            LoadBooks();
            LoadReaders();
        }

        private void EmployeeMainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadReaders()
        {
            using (var db = new LibraryDbContext())
            {
                var readers = db.Readers
                    .ToList();

                readersDataGridView.DataSource = readers
                    .Select(r => new
                    {
                        r?.ReaderId,
                        FullName = r?.FullName ?? "",
                        Email = r?.UserCredentials?.Email ?? "",
                        PhoneNumber = r?.PhoneNumber ?? "",
                        r?.DateOfBirth,
                        
                    }).ToList();
            }
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
                        Author = b.Author.AuthorFullName,
                    }).ToList();
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
            this.Close();
        }
    }
}
