namespace librarian.Forms
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.FormClosing += BaseForm_FormClosing;
        }

        private void BaseForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
