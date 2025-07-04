using librarian.Data;
using librarian.Models;

namespace librarian.Forms
{
    public partial class BlacklistReaderForm : BaseForm
    {
        private readonly int _readerId;

        private BaseForm _employeeMainForm;

        public BlacklistReaderForm(int readerId, BaseForm employeeMainForm)
        {
            InitializeComponent();
            _readerId = readerId;
            LoadReaderInfo();
            _employeeMainForm = employeeMainForm;

            this.Text = "Librarian";
        }

        private void LoadReaderInfo()
        {
            using (var db = new LibraryDbContext())
            {
                var reader = db.Readers.FirstOrDefault(r => r.ReaderId == _readerId);
                if (reader != null)
                {
                    readerNameLabel.Text = "Reader name: " + reader.FullName;
                }
            }
        }

        private void blacklistReaderButton_Click(object sender, EventArgs e)
        {
            var reason = reasonTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Reason cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new LibraryDbContext())
            {
                var removalDate = endDatePicker.Value;

                if (removalDate <= DateTime.Now)
                {
                    MessageBox.Show("End date must be future date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var blacklistEntry = new BlacklistedReader
                {
                    ReaderId = _readerId,
                    Reason = reason,
                    BlacklistedDate = DateTime.Now,
                    RemovalDate = removalDate
                };

                db.BlacklistedReaders.Add(blacklistEntry);
                db.SaveChanges();

                MessageBox.Show("Reader blacklisted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _employeeMainForm.Show();
            this.Hide();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _employeeMainForm.Show();
            this.Hide();
        }
    }
}
