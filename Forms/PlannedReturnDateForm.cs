namespace librarian.Forms
{
    public partial class PlannedReturnDateForm : Form
    {
        public DateTime? PlannedReturnDate => plannedReturnDatePicker.Value.Date;

        public PlannedReturnDateForm()
        {
            InitializeComponent();

            this.Name = "Planned Return Date";
        }

        private void confirmRentalButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
