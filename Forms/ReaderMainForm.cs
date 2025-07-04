namespace librarian.Forms
{
    public partial class ReaderMainForm : Form
    {
        private readonly int _userId;

        public ReaderMainForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            //LoadUserData();
            //LoadBooks();
        }

        //private void LoadUserData()
        //{
        //    using (var db = new LibraryDbContext())
        //    {
        //        var reader = db.Readers.Include(r => r.UserCredential)
        //                               .FirstOrDefault(r => r.UserCredentialId == _userId);
        //        if (reader != null)
        //        {
        //            welcomeLabel.Text = $"Witaj, {reader.FirstName}";
        //        }
        //    }
        //}

        //private void LoadBooks()
        //{
        //    using (var db = new LibraryDbContext())
        //    {
        //        var books = db.Books.Include(b => b.Author)
        //                            .Select(b => new
        //                            {
        //                                Tytuł = b.Title,
        //                                Autor = b.Author.Name,
        //                                Rok = b.YearPublished
        //                            })
        //                            .ToList();

        //        booksDataGridView.DataSource = books;
        //    }
        //}

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
