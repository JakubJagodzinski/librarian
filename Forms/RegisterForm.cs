using librarian.Data;
using librarian.Models;

namespace librarian.Forms
{
    public partial class RegisterForm : BaseForm
    {
        private BaseForm _loginForm;

        public RegisterForm(BaseForm loginForm)
        {
            InitializeComponent();

            this.Text = "Librarian";

            _loginForm = loginForm;

            AddRolesToComboBox();

            AddVisibleChanged();
        }

        private void AddVisibleChanged()
        {
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible)
                {
                    fullNameTextBox.Text = null;
                    emailTextBox.Text = null;
                    passwordTextBox.Text = null;
                    confirmPasswordTextBox.Text = null;
                    phoneNumberTextBox.Text = null;
                    var role = roleComboBox.SelectedIndex = 0;
                }
            };
        }

        private void AddRolesToComboBox()
        {
            roleComboBox.Items.Add("Reader");
            roleComboBox.Items.Add("Employee");
            roleComboBox.SelectedIndex = 0;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var fullName = fullNameTextBox.Text.Trim();
            var email = emailTextBox.Text.Trim();
            var password = passwordTextBox.Text;
            var confirm = confirmPasswordTextBox.Text;
            var role = roleComboBox.SelectedItem?.ToString();
            var phoneNumber = phoneNumberTextBox.Text.Trim();

            if (
                string.IsNullOrEmpty(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role) ||
                string.IsNullOrWhiteSpace(phoneNumber)
                )
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords don't match.");
                return;
            }

            using var db = new LibraryDbContext();

            if (db.UserCredentials.Any(u => u.Email == email))
            {
                MessageBox.Show("Email already taken.");
                return;
            }

            var hashed = PasswordHasher.Hash(password);
            var credential = new UserCredentials
            {
                Email = email,
                PasswordHash = hashed
            };

            if (role == "Reader")
            {
                var reader = new Reader
                {
                    FullName = fullName,
                    Email = email,
                    PhoneNumber = phoneNumber
                };
                db.Readers.Add(reader);
                db.SaveChanges();
                credential.ReaderId = reader.ReaderId;
            }
            else if (role == "Employee")
            {
                var emp = new Employee
                {
                    FullName = fullName,
                    Email = email,
                    PhoneNumber = phoneNumber
                };
                db.Employees.Add(emp);
                db.SaveChanges();
                credential.EmployeeId = emp.EmployeeId;
            }

            db.UserCredentials.Add(credential);
            db.SaveChanges();

            MessageBox.Show("Registered successfully.");

            _loginForm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Hide();
        }
    }
}
