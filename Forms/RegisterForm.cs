using librarian.Data;
using librarian.Models;

namespace librarian.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            roleComboBox.Items.Add("Reader");
            roleComboBox.Items.Add("Employee");
            roleComboBox.SelectedIndex = 0;

        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text.Trim();
            var password = passwordTextBox.Text;
            var confirm = confirmPasswordTextBox.Text;
            var role = roleComboBox.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
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
                    FullName = fullNameTextBox.Text,
                    Email = emailTextBox.Text,
                    PhoneNumber = phoneNumberTextBox.Text
                };
                db.Readers.Add(reader);
                db.SaveChanges();
                credential.ReaderId = reader.ReaderId;
            }
            else if (role == "Employee")
            {
                var emp = new Employee {
                    FullName= fullNameTextBox.Text,
                    Email = emailTextBox.Text,
                    PhoneNumber = phoneNumberTextBox.Text
                };
                var reader = new Employee
                {
                    FullName = fullNameTextBox.Text,
                    Email = emailTextBox.Text
                };
                db.Employees.Add(emp);
                db.SaveChanges();
                credential.EmployeeId = emp.EmployeeId;
            }

            db.UserCredentials.Add(credential);
            db.SaveChanges();

            MessageBox.Show("Registered successfully.");

            var loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            loginForm.Show();
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            loginForm.Show();
            this.Hide();
        }
    }
}
