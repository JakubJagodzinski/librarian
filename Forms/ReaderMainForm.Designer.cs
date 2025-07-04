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
            booksTab = new TabPage();
            booksDataGridView = new DataGridView();
            rentalsTab = new TabPage();
            myAccountTab = new TabPage();
            myRentalsDataGridView = new DataGridView();
            mainTabControl.SuspendLayout();
            booksTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).BeginInit();
            rentalsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myRentalsDataGridView).BeginInit();
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
            logoutButton.Location = new Point(698, 12);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "Log out";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(booksTab);
            mainTabControl.Controls.Add(rentalsTab);
            mainTabControl.Controls.Add(myAccountTab);
            mainTabControl.Location = new Point(22, 43);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(751, 395);
            mainTabControl.TabIndex = 3;
            // 
            // booksTab
            // 
            booksTab.Controls.Add(booksDataGridView);
            booksTab.Location = new Point(4, 24);
            booksTab.Name = "booksTab";
            booksTab.Padding = new Padding(3);
            booksTab.Size = new Size(743, 367);
            booksTab.TabIndex = 0;
            booksTab.Text = "Books";
            booksTab.UseVisualStyleBackColor = true;
            // 
            // booksDataGridView
            // 
            booksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksDataGridView.Location = new Point(0, 0);
            booksDataGridView.Name = "booksDataGridView";
            booksDataGridView.Size = new Size(743, 367);
            booksDataGridView.TabIndex = 0;
            // 
            // rentalsTab
            // 
            rentalsTab.Controls.Add(myRentalsDataGridView);
            rentalsTab.Location = new Point(4, 24);
            rentalsTab.Name = "rentalsTab";
            rentalsTab.Padding = new Padding(3);
            rentalsTab.Size = new Size(743, 367);
            rentalsTab.TabIndex = 1;
            rentalsTab.Text = "My Rentals";
            rentalsTab.UseVisualStyleBackColor = true;
            // 
            // myAccountTab
            // 
            myAccountTab.Location = new Point(4, 24);
            myAccountTab.Name = "myAccountTab";
            myAccountTab.Padding = new Padding(3);
            myAccountTab.Size = new Size(743, 367);
            myAccountTab.TabIndex = 2;
            myAccountTab.Text = "My Account";
            myAccountTab.UseVisualStyleBackColor = true;
            // 
            // myRentalsDataGridView
            // 
            myRentalsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myRentalsDataGridView.Location = new Point(0, 0);
            myRentalsDataGridView.Name = "myRentalsDataGridView";
            myRentalsDataGridView.Size = new Size(743, 367);
            myRentalsDataGridView.TabIndex = 0;
            // 
            // ReaderMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainTabControl);
            Controls.Add(logoutButton);
            Controls.Add(welcomeLabel);
            Name = "ReaderMainForm";
            Text = "ReaderMainForm";
            mainTabControl.ResumeLayout(false);
            booksTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).EndInit();
            rentalsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)myRentalsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        private Button logoutButton;
        private TabControl mainTabControl;
        private TabPage booksTab;
        private TabPage rentalsTab;
        private TabPage myAccountTab;
        private DataGridView booksDataGridView;
        private DataGridView myRentalsDataGridView;
    }
}