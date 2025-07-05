namespace librarian.Forms
{
    partial class ReaderMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            welcomeLabel = new Label();
            logoutButton = new Button();
            mainTabControl = new TabControl();
            booksTabPage = new TabPage();
            rentBookButton = new Button();
            booksDataGridView = new DataGridView();
            myRentalsTabPage = new TabPage();
            endRentalButton = new Button();
            myRentalsDataGridView = new DataGridView();
            rentalsHistoryTabPage = new TabPage();
            rentalsHistoryDataGridView = new DataGridView();
            statisticsTabPage = new TabPage();
            loadStatisticsButton = new Button();
            endDateLabel = new Label();
            endDatePicker = new DateTimePicker();
            startDateLabel = new Label();
            startDatePicker = new DateTimePicker();
            totalRentalsLabel = new Label();
            formsPlot = new ScottPlot.WinForms.FormsPlot();
            myAccountTabPage = new TabPage();
            fullNameLabel = new Label();
            birthdateLabel = new Label();
            phoneNumberLabel = new Label();
            emailLabel = new Label();
            mainTabControl.SuspendLayout();
            booksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).BeginInit();
            myRentalsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myRentalsDataGridView).BeginInit();
            rentalsHistoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rentalsHistoryDataGridView).BeginInit();
            statisticsTabPage.SuspendLayout();
            myAccountTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(365, 9);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(57, 15);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Welcome";
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(677, 14);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(86, 23);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "Log out";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(booksTabPage);
            mainTabControl.Controls.Add(myRentalsTabPage);
            mainTabControl.Controls.Add(rentalsHistoryTabPage);
            mainTabControl.Controls.Add(statisticsTabPage);
            mainTabControl.Controls.Add(myAccountTabPage);
            mainTabControl.Location = new Point(22, 43);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(751, 395);
            mainTabControl.TabIndex = 3;
            mainTabControl.SelectedIndexChanged += mainTabControl_SelectedIndexChanged;
            // 
            // booksTabPage
            // 
            booksTabPage.Controls.Add(rentBookButton);
            booksTabPage.Controls.Add(booksDataGridView);
            booksTabPage.Location = new Point(4, 24);
            booksTabPage.Name = "booksTabPage";
            booksTabPage.Padding = new Padding(3);
            booksTabPage.Size = new Size(743, 367);
            booksTabPage.TabIndex = 0;
            booksTabPage.Text = "Books";
            booksTabPage.UseVisualStyleBackColor = true;
            // 
            // rentBookButton
            // 
            rentBookButton.Location = new Point(651, 6);
            rentBookButton.Name = "rentBookButton";
            rentBookButton.Size = new Size(86, 23);
            rentBookButton.TabIndex = 1;
            rentBookButton.Text = "Rent a book";
            rentBookButton.UseVisualStyleBackColor = true;
            rentBookButton.Click += rentBookButton_Click;
            // 
            // booksDataGridView
            // 
            booksDataGridView.AllowUserToAddRows = false;
            booksDataGridView.AllowUserToDeleteRows = false;
            booksDataGridView.AllowUserToResizeRows = false;
            booksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksDataGridView.Location = new Point(0, 0);
            booksDataGridView.Name = "booksDataGridView";
            booksDataGridView.Size = new Size(645, 367);
            booksDataGridView.TabIndex = 0;
            booksDataGridView.CellClick += booksDataGridView_CellClick;
            // 
            // myRentalsTabPage
            // 
            myRentalsTabPage.Controls.Add(endRentalButton);
            myRentalsTabPage.Controls.Add(myRentalsDataGridView);
            myRentalsTabPage.Location = new Point(4, 24);
            myRentalsTabPage.Name = "myRentalsTabPage";
            myRentalsTabPage.Padding = new Padding(3);
            myRentalsTabPage.Size = new Size(743, 367);
            myRentalsTabPage.TabIndex = 1;
            myRentalsTabPage.Text = "My Rentals";
            myRentalsTabPage.UseVisualStyleBackColor = true;
            // 
            // endRentalButton
            // 
            endRentalButton.Location = new Point(651, 6);
            endRentalButton.Name = "endRentalButton";
            endRentalButton.Size = new Size(86, 23);
            endRentalButton.TabIndex = 1;
            endRentalButton.Text = "End rental";
            endRentalButton.UseVisualStyleBackColor = true;
            endRentalButton.Click += endRentalButton_Click;
            // 
            // myRentalsDataGridView
            // 
            myRentalsDataGridView.AllowUserToAddRows = false;
            myRentalsDataGridView.AllowUserToDeleteRows = false;
            myRentalsDataGridView.AllowUserToResizeRows = false;
            myRentalsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myRentalsDataGridView.Location = new Point(0, 0);
            myRentalsDataGridView.Name = "myRentalsDataGridView";
            myRentalsDataGridView.Size = new Size(645, 367);
            myRentalsDataGridView.TabIndex = 0;
            myRentalsDataGridView.CellClick += rentalsDataGridView_CellClick;
            // 
            // rentalsHistoryTabPage
            // 
            rentalsHistoryTabPage.Controls.Add(rentalsHistoryDataGridView);
            rentalsHistoryTabPage.Location = new Point(4, 24);
            rentalsHistoryTabPage.Name = "rentalsHistoryTabPage";
            rentalsHistoryTabPage.Padding = new Padding(3);
            rentalsHistoryTabPage.Size = new Size(743, 367);
            rentalsHistoryTabPage.TabIndex = 3;
            rentalsHistoryTabPage.Text = "Rentals History";
            rentalsHistoryTabPage.UseVisualStyleBackColor = true;
            // 
            // rentalsHistoryDataGridView
            // 
            rentalsHistoryDataGridView.AllowUserToAddRows = false;
            rentalsHistoryDataGridView.AllowUserToDeleteRows = false;
            rentalsHistoryDataGridView.AllowUserToResizeRows = false;
            rentalsHistoryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            rentalsHistoryDataGridView.Location = new Point(0, 0);
            rentalsHistoryDataGridView.Name = "rentalsHistoryDataGridView";
            rentalsHistoryDataGridView.Size = new Size(743, 367);
            rentalsHistoryDataGridView.TabIndex = 0;
            // 
            // statisticsTabPage
            // 
            statisticsTabPage.Controls.Add(loadStatisticsButton);
            statisticsTabPage.Controls.Add(endDateLabel);
            statisticsTabPage.Controls.Add(endDatePicker);
            statisticsTabPage.Controls.Add(startDateLabel);
            statisticsTabPage.Controls.Add(startDatePicker);
            statisticsTabPage.Controls.Add(totalRentalsLabel);
            statisticsTabPage.Controls.Add(formsPlot);
            statisticsTabPage.Location = new Point(4, 24);
            statisticsTabPage.Name = "statisticsTabPage";
            statisticsTabPage.Padding = new Padding(3);
            statisticsTabPage.Size = new Size(743, 367);
            statisticsTabPage.TabIndex = 4;
            statisticsTabPage.Text = "Statistics";
            statisticsTabPage.UseVisualStyleBackColor = true;
            // 
            // loadStatisticsButton
            // 
            loadStatisticsButton.Location = new Point(116, 328);
            loadStatisticsButton.Name = "loadStatisticsButton";
            loadStatisticsButton.Size = new Size(101, 23);
            loadStatisticsButton.TabIndex = 7;
            loadStatisticsButton.Text = "Load statistics";
            loadStatisticsButton.UseVisualStyleBackColor = true;
            loadStatisticsButton.Click += loadStatisticsButton_Click;
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Location = new Point(17, 129);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(56, 15);
            endDateLabel.TabIndex = 6;
            endDateLabel.Text = "End date:";
            // 
            // endDatePicker
            // 
            endDatePicker.Location = new Point(17, 147);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(200, 23);
            endDatePicker.TabIndex = 5;
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new Point(17, 60);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(60, 15);
            startDateLabel.TabIndex = 4;
            startDateLabel.Text = "Start date:";
            // 
            // startDatePicker
            // 
            startDatePicker.Location = new Point(17, 78);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(200, 23);
            startDatePicker.TabIndex = 3;
            // 
            // totalRentalsLabel
            // 
            totalRentalsLabel.AutoSize = true;
            totalRentalsLabel.Location = new Point(17, 19);
            totalRentalsLabel.Name = "totalRentalsLabel";
            totalRentalsLabel.Size = new Size(82, 15);
            totalRentalsLabel.TabIndex = 1;
            totalRentalsLabel.Text = "Total rentals: ?";
            // 
            // formsPlot
            // 
            formsPlot.DisplayScale = 1F;
            formsPlot.Location = new Point(324, 0);
            formsPlot.Name = "formsPlot";
            formsPlot.Size = new Size(419, 367);
            formsPlot.TabIndex = 0;
            // 
            // myAccountTabPage
            // 
            myAccountTabPage.Controls.Add(fullNameLabel);
            myAccountTabPage.Controls.Add(birthdateLabel);
            myAccountTabPage.Controls.Add(phoneNumberLabel);
            myAccountTabPage.Controls.Add(emailLabel);
            myAccountTabPage.Location = new Point(4, 24);
            myAccountTabPage.Name = "myAccountTabPage";
            myAccountTabPage.Padding = new Padding(3);
            myAccountTabPage.Size = new Size(743, 367);
            myAccountTabPage.TabIndex = 2;
            myAccountTabPage.Text = "My Account";
            myAccountTabPage.UseVisualStyleBackColor = true;
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new Point(21, 31);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new Size(70, 15);
            fullNameLabel.TabIndex = 3;
            fullNameLabel.Text = "Full name: ?";
            // 
            // birthdateLabel
            // 
            birthdateLabel.AutoSize = true;
            birthdateLabel.Location = new Point(21, 204);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Size = new Size(66, 15);
            birthdateLabel.TabIndex = 2;
            birthdateLabel.Text = "Birthdate: ?";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(21, 146);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(97, 15);
            phoneNumberLabel.TabIndex = 1;
            phoneNumberLabel.Text = "Phone number: ?";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(21, 85);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(47, 15);
            emailLabel.TabIndex = 0;
            emailLabel.Text = "Email: ?";
            // 
            // ReaderMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(logoutButton);
            Controls.Add(welcomeLabel);
            Controls.Add(mainTabControl);
            Name = "ReaderMainForm";
            Text = "ReaderMainForm";
            mainTabControl.ResumeLayout(false);
            booksTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).EndInit();
            myRentalsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)myRentalsDataGridView).EndInit();
            rentalsHistoryTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rentalsHistoryDataGridView).EndInit();
            statisticsTabPage.ResumeLayout(false);
            statisticsTabPage.PerformLayout();
            myAccountTabPage.ResumeLayout(false);
            myAccountTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        private Button logoutButton;
        private TabControl mainTabControl;
        private TabPage booksTabPage;
        private TabPage myRentalsTabPage;
        private TabPage myAccountTabPage;
        private DataGridView booksDataGridView;
        private DataGridView myRentalsDataGridView;
        private Button endRentalButton;
        private TabPage rentalsHistoryTabPage;
        private DataGridView rentalsHistoryDataGridView;
        private Button rentBookButton;
        private TabPage statisticsTabPage;
        private Label endDateLabel;
        private DateTimePicker endDatePicker;
        private Label startDateLabel;
        private DateTimePicker startDatePicker;
        private Label totalRentalsLabel;
        private ScottPlot.WinForms.FormsPlot formsPlot;
        private Button loadStatisticsButton;
        private Label emailLabel;
        private Label fullNameLabel;
        private Label birthdateLabel;
        private Label phoneNumberLabel;
    }
}