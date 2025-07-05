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
            booksDataGridView = new DataGridView();
            myRentalsTabPage = new TabPage();
            endRentalButton = new Button();
            myRentalsDataGridView = new DataGridView();
            myAccountTabPage = new TabPage();
            rentalsHistoryTabPage = new TabPage();
            rentalsHistoryDataGridView = new DataGridView();
            mainTabControl.SuspendLayout();
            booksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).BeginInit();
            myRentalsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myRentalsDataGridView).BeginInit();
            rentalsHistoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rentalsHistoryDataGridView).BeginInit();
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
            mainTabControl.Controls.Add(myAccountTabPage);
            mainTabControl.Controls.Add(rentalsHistoryTabPage);
            mainTabControl.Location = new Point(22, 43);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(751, 395);
            mainTabControl.TabIndex = 3;
            mainTabControl.SelectedIndexChanged += mainTabControl_SelectedIndexChanged;
            // 
            // booksTabPage
            // 
            booksTabPage.Controls.Add(booksDataGridView);
            booksTabPage.Location = new Point(4, 24);
            booksTabPage.Name = "booksTabPage";
            booksTabPage.Padding = new Padding(3);
            booksTabPage.Size = new Size(743, 367);
            booksTabPage.TabIndex = 0;
            booksTabPage.Text = "Books";
            booksTabPage.UseVisualStyleBackColor = true;
            // 
            // booksDataGridView
            // 
            booksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksDataGridView.Location = new Point(0, 0);
            booksDataGridView.Name = "booksDataGridView";
            booksDataGridView.Size = new Size(743, 367);
            booksDataGridView.TabIndex = 0;
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
            myRentalsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myRentalsDataGridView.Location = new Point(0, 0);
            myRentalsDataGridView.Name = "myRentalsDataGridView";
            myRentalsDataGridView.Size = new Size(645, 367);
            myRentalsDataGridView.TabIndex = 0;
            myRentalsDataGridView.CellClick += rentalsDataGridView_CellClick;
            // 
            // myAccountTabPage
            // 
            myAccountTabPage.Location = new Point(4, 24);
            myAccountTabPage.Name = "myAccountTabPage";
            myAccountTabPage.Padding = new Padding(3);
            myAccountTabPage.Size = new Size(743, 367);
            myAccountTabPage.TabIndex = 2;
            myAccountTabPage.Text = "My Account";
            myAccountTabPage.UseVisualStyleBackColor = true;
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
            rentalsHistoryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            rentalsHistoryDataGridView.Location = new Point(0, 0);
            rentalsHistoryDataGridView.Name = "rentalsHistoryDataGridView";
            rentalsHistoryDataGridView.Size = new Size(743, 367);
            rentalsHistoryDataGridView.TabIndex = 0;
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
    }
}