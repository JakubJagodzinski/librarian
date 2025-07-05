using librarian.Data;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class LoginForm : BaseForm
    {
        private BaseForm _registerForm;

        public LoginForm()
        {
            InitializeComponent();

            this.Text = "Librarian";

            AddVisibleChanged();
        }

        private void AddVisibleChanged()
        {
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible)
                {
                    emailTextBox.Text = null;
                    passwordTextBox.Text = null;
                }
            };
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text.Trim();
            var password = passwordTextBox.Text;

            using var db = new LibraryDbContext();
            var user = db.UserCredentials
                .Include(u => u.Reader)
                .Include(u => u.Employee)
                .FirstOrDefault(u => u.Email == email);

            if (user == null || !PasswordHasher.Verify(password, user.PasswordHash))
            {
                MessageBox.Show(this, "Wrong email or password.");
                return;
            }

            if (user.Reader != null)
            {
                var readerMainForm = new ReaderMainForm(user.Reader.ReaderId, this);
                readerMainForm.StartPosition = FormStartPosition.Manual;
                readerMainForm.Location = this.Location;
                readerMainForm.Show();
                this.Hide();
            }
            else if (user.Employee != null)
            {
                var employeeMainForm = new EmployeeMainForm(user.Employee.EmployeeId, this);
                employeeMainForm.StartPosition = FormStartPosition.Manual;
                employeeMainForm.Location = this.Location;
                employeeMainForm.Show();
                this.Hide();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (_registerForm == null)
            {
                _registerForm = new RegisterForm(this);
            }

            _registerForm.StartPosition = FormStartPosition.Manual;
            _registerForm.Location = this.Location;
            _registerForm.Show();
            this.Hide();
        }
    }
}
