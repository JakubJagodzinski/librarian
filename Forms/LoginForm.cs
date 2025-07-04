using librarian.Data;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
                MessageBox.Show("Wrong email or password.");
                return;
            }

            if (user.Reader != null)
            {
                var readerMainForm = new ReaderMainForm(user.Reader.ReaderId);
                readerMainForm.StartPosition = FormStartPosition.Manual;
                readerMainForm.Location = this.Location;
                readerMainForm.Show();
                this.Hide();
            }
            else if (user.Employee != null)
            {
                var employeeMainForm = new EmployeeMainForm(user.Employee.EmployeeId);
                employeeMainForm.StartPosition = FormStartPosition.Manual;
                employeeMainForm.Location = this.Location;
                employeeMainForm.Show();
                this.Hide();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.StartPosition = FormStartPosition.Manual;
            registerForm.Location = this.Location;
            registerForm.Show();
            this.Hide();
        }
    }
}
