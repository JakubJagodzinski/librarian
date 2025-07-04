namespace librarian.Forms
{
    public partial class EmployeeMainForm : Form
    {

        private readonly int _userId;

        public EmployeeMainForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void EmployeeMainForm_Load(object sender, EventArgs e)
        {

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
