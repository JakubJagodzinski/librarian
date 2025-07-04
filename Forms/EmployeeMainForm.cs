using System.Windows.Forms;
using librarian.Data;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class EmployeeMainForm : BaseForm
    {

        private readonly int _userId;

        private int? selectedReaderId = null;

        private int? selectedBlacklistEntryId = null;

        public EmployeeMainForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            LoadUserData();
            LoadBooks();
            LoadReaders();
            LoadBlacklistedReaders();
        }

        private void EmployeeMainForm_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["blacklistedReadersTabPage"])
            {
                LoadBlacklistedReaders();
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["readersTabPage"])
            {
                LoadReaders();
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["booksTabPage"])
            {
                LoadBooks();
            }
        }

        private void LoadBlacklistedReaders()
        {
            using (var db = new LibraryDbContext())
            {
                var blacklistedReaders = db.BlacklistedReaders
                    .Include(b => b.Reader)
                    .Where(b => b.RemovalDate == null || b.RemovalDate > DateTime.Now)
                    .ToList();

                blacklistedReadersDataGridView.DataSource = blacklistedReaders
                    .Select(b => new
                    {
                        b.BlacklistedReaderId,
                        ReaderName = b.Reader.FullName,
                        b.Reason,
                        BlacklistedDate = b.BlacklistedDate.ToShortDateString(),
                        RemovalDate = b.RemovalDate?.ToShortDateString() ?? "–"
                    })
                    .ToList();
            }
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
                        Email = r?.Email ?? "",
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
                        Author = b.Author?.AuthorFullName ?? "",
                        b.PublishedYear,
                        b.Pages,
                        b.InStock
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
            this.Hide();
        }

        private void readersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = readersDataGridView.Rows[e.RowIndex];
                selectedReaderId = Convert.ToInt32(row.Cells["ReaderId"].Value);

                //MessageBox.Show($"Selected ReaderId: {selectedReaderId}");
            }
        }

        private void blacklistedReadersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = blacklistedReadersDataGridView.Rows[e.RowIndex];
                selectedBlacklistEntryId = Convert.ToInt32(row.Cells["BlacklistedReaderId"].Value);

                //MessageBox.Show($"Selected BlacklistEntryId: {selectedBlacklistEntryId}");
            }
        }

        private void blacklistReaderButton_Click(object sender, EventArgs e)
        {
            if (selectedReaderId == null)
            {
                MessageBox.Show("You have to select reader you want to blacklist.");
                return;
            }

            var blacklistReaderForm = new BlacklistReaderForm(selectedReaderId.Value, this);
            blacklistReaderForm.StartPosition = FormStartPosition.Manual;
            blacklistReaderForm.Location = this.Location;

            this.Hide();
            blacklistReaderForm.Show();
        }

        private void removeFromBlacklistButton_Click(object sender, EventArgs e)
        {
            if (blacklistedReadersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a blacklisted reader entry to remove.");
                return;
            }

            var selectedRow = blacklistedReadersDataGridView.SelectedRows[0];
            var blacklistEntryId = Convert.ToInt32(selectedRow.Cells["BlacklistedReaderId"].Value);

            using (var db = new LibraryDbContext())
            {
                var entry = db.BlacklistedReaders.FirstOrDefault(b => b.BlacklistedReaderId == blacklistEntryId);

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
    }
}
