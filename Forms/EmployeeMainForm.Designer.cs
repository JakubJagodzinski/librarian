namespace librarian.Forms
{
    partial class EmployeeMainForm
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
            components = new System.ComponentModel.Container();
            welcomeLabel = new Label();
            logoutButton = new Button();
            tabControl1 = new TabControl();
            booksTabPage = new TabPage();
            editBookButton = new Button();
            addBookButton = new Button();
            booksDataGridView = new DataGridView();
            readersTabPage = new TabPage();
            blacklistReaderButton = new Button();
            readersDataGridView = new DataGridView();
            blacklistedReadersTabPage = new TabPage();
            removeFromBlacklistButton = new Button();
            blacklistedReadersDataGridView = new DataGridView();
            myAccountTabPage = new TabPage();
            removePhotoButton = new Button();
            photoBox = new PictureBox();
            editPhotoButton = new Button();
            hireDateLabel = new Label();
            phoneNumberLabel = new Label();
            emailLabel = new Label();
            fullNameLabel = new Label();
            pageSetupDialog1 = new PageSetupDialog();
            libraryDbContextBindingSource = new BindingSource(components);
            bookBindingSource = new BindingSource(components);
            tabControl1.SuspendLayout();
            booksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).BeginInit();
            readersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)readersDataGridView).BeginInit();
            blacklistedReadersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blacklistedReadersDataGridView).BeginInit();
            myAccountTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)photoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)libraryDbContextBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).BeginInit();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(342, 29);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(104, 15);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Welcome, {name}!";
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(686, 25);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Log out";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(booksTabPage);
            tabControl1.Controls.Add(readersTabPage);
            tabControl1.Controls.Add(blacklistedReadersTabPage);
            tabControl1.Controls.Add(myAccountTabPage);
            tabControl1.Location = new Point(30, 72);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(743, 328);
            tabControl1.TabIndex = 2;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // booksTabPage
            // 
            booksTabPage.Controls.Add(editBookButton);
            booksTabPage.Controls.Add(addBookButton);
            booksTabPage.Controls.Add(booksDataGridView);
            booksTabPage.Location = new Point(4, 24);
            booksTabPage.Name = "booksTabPage";
            booksTabPage.Padding = new Padding(3);
            booksTabPage.Size = new Size(735, 300);
            booksTabPage.TabIndex = 0;
            booksTabPage.Text = "Books";
            booksTabPage.UseVisualStyleBackColor = true;
            // 
            // editBookButton
            // 
            editBookButton.Location = new Point(652, 35);
            editBookButton.Name = "editBookButton";
            editBookButton.Size = new Size(75, 23);
            editBookButton.TabIndex = 2;
            editBookButton.Text = "Edit book";
            editBookButton.UseVisualStyleBackColor = true;
            editBookButton.Click += editBookButton_Click;
            // 
            // addBookButton
            // 
            addBookButton.Location = new Point(652, 6);
            addBookButton.Name = "addBookButton";
            addBookButton.Size = new Size(75, 23);
            addBookButton.TabIndex = 1;
            addBookButton.Text = "Add book";
            addBookButton.UseVisualStyleBackColor = true;
            addBookButton.Click += addBookButton_Click;
            // 
            // booksDataGridView
            // 
            booksDataGridView.AllowUserToAddRows = false;
            booksDataGridView.AllowUserToDeleteRows = false;
            booksDataGridView.AllowUserToResizeRows = false;
            booksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksDataGridView.Location = new Point(0, 0);
            booksDataGridView.Name = "booksDataGridView";
            booksDataGridView.Size = new Size(645, 300);
            booksDataGridView.TabIndex = 0;
            booksDataGridView.CellClick += booksDataGridView_CellClick;
            // 
            // readersTabPage
            // 
            readersTabPage.Controls.Add(blacklistReaderButton);
            readersTabPage.Controls.Add(readersDataGridView);
            readersTabPage.Location = new Point(4, 24);
            readersTabPage.Name = "readersTabPage";
            readersTabPage.Padding = new Padding(3);
            readersTabPage.Size = new Size(735, 300);
            readersTabPage.TabIndex = 1;
            readersTabPage.Text = "Readers";
            readersTabPage.UseVisualStyleBackColor = true;
            // 
            // blacklistReaderButton
            // 
            blacklistReaderButton.Location = new Point(652, 6);
            blacklistReaderButton.Name = "blacklistReaderButton";
            blacklistReaderButton.Size = new Size(75, 41);
            blacklistReaderButton.TabIndex = 1;
            blacklistReaderButton.Text = "Blacklist reader";
            blacklistReaderButton.UseVisualStyleBackColor = true;
            blacklistReaderButton.Click += blacklistReaderButton_Click;
            // 
            // readersDataGridView
            // 
            readersDataGridView.AllowUserToAddRows = false;
            readersDataGridView.AllowUserToDeleteRows = false;
            readersDataGridView.AllowUserToResizeRows = false;
            readersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            readersDataGridView.Location = new Point(0, 0);
            readersDataGridView.Name = "readersDataGridView";
            readersDataGridView.Size = new Size(645, 300);
            readersDataGridView.TabIndex = 0;
            readersDataGridView.CellClick += readersDataGridView_CellClick;
            // 
            // blacklistedReadersTabPage
            // 
            blacklistedReadersTabPage.Controls.Add(removeFromBlacklistButton);
            blacklistedReadersTabPage.Controls.Add(blacklistedReadersDataGridView);
            blacklistedReadersTabPage.Location = new Point(4, 24);
            blacklistedReadersTabPage.Name = "blacklistedReadersTabPage";
            blacklistedReadersTabPage.Padding = new Padding(3);
            blacklistedReadersTabPage.Size = new Size(735, 300);
            blacklistedReadersTabPage.TabIndex = 2;
            blacklistedReadersTabPage.Text = "Blacklisted Readers";
            blacklistedReadersTabPage.UseVisualStyleBackColor = true;
            // 
            // removeFromBlacklistButton
            // 
            removeFromBlacklistButton.Location = new Point(651, 6);
            removeFromBlacklistButton.Name = "removeFromBlacklistButton";
            removeFromBlacklistButton.Size = new Size(75, 58);
            removeFromBlacklistButton.TabIndex = 1;
            removeFromBlacklistButton.Text = "Remove from blacklist";
            removeFromBlacklistButton.UseVisualStyleBackColor = true;
            removeFromBlacklistButton.Click += removeFromBlacklistButton_Click;
            // 
            // blacklistedReadersDataGridView
            // 
            blacklistedReadersDataGridView.AllowUserToAddRows = false;
            blacklistedReadersDataGridView.AllowUserToDeleteRows = false;
            blacklistedReadersDataGridView.AllowUserToResizeRows = false;
            blacklistedReadersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            blacklistedReadersDataGridView.Location = new Point(0, 0);
            blacklistedReadersDataGridView.Name = "blacklistedReadersDataGridView";
            blacklistedReadersDataGridView.Size = new Size(645, 300);
            blacklistedReadersDataGridView.TabIndex = 0;
            blacklistedReadersDataGridView.CellClick += blacklistedReadersDataGridView_CellClick;
            // 
            // myAccountTabPage
            // 
            myAccountTabPage.Controls.Add(removePhotoButton);
            myAccountTabPage.Controls.Add(photoBox);
            myAccountTabPage.Controls.Add(editPhotoButton);
            myAccountTabPage.Controls.Add(hireDateLabel);
            myAccountTabPage.Controls.Add(phoneNumberLabel);
            myAccountTabPage.Controls.Add(emailLabel);
            myAccountTabPage.Controls.Add(fullNameLabel);
            myAccountTabPage.Location = new Point(4, 24);
            myAccountTabPage.Name = "myAccountTabPage";
            myAccountTabPage.Padding = new Padding(3);
            myAccountTabPage.Size = new Size(735, 300);
            myAccountTabPage.TabIndex = 3;
            myAccountTabPage.Text = "My Account";
            myAccountTabPage.UseVisualStyleBackColor = true;
            // 
            // removePhotoButton
            // 
            removePhotoButton.Location = new Point(36, 256);
            removePhotoButton.Name = "removePhotoButton";
            removePhotoButton.Size = new Size(102, 23);
            removePhotoButton.TabIndex = 6;
            removePhotoButton.Text = "Remove photo";
            removePhotoButton.UseVisualStyleBackColor = true;
            removePhotoButton.Click += removePhotoButton_Click;
            // 
            // photoBox
            // 
            photoBox.BorderStyle = BorderStyle.FixedSingle;
            photoBox.Location = new Point(20, 46);
            photoBox.Name = "photoBox";
            photoBox.Size = new Size(135, 165);
            photoBox.SizeMode = PictureBoxSizeMode.Zoom;
            photoBox.TabIndex = 4;
            photoBox.TabStop = false;
            // 
            // editPhotoButton
            // 
            editPhotoButton.Location = new Point(36, 227);
            editPhotoButton.Name = "editPhotoButton";
            editPhotoButton.Size = new Size(102, 23);
            editPhotoButton.TabIndex = 5;
            editPhotoButton.Text = "Edit photo";
            editPhotoButton.UseVisualStyleBackColor = true;
            editPhotoButton.Click += editPhotoButton_Click;
            // 
            // hireDateLabel
            // 
            hireDateLabel.AutoSize = true;
            hireDateLabel.Location = new Point(200, 169);
            hireDateLabel.Name = "hireDateLabel";
            hireDateLabel.Size = new Size(66, 15);
            hireDateLabel.TabIndex = 3;
            hireDateLabel.Text = "Hire date: ?";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(200, 128);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(97, 15);
            phoneNumberLabel.TabIndex = 2;
            phoneNumberLabel.Text = "Phone number: ?";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(200, 88);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(47, 15);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Email: ?";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new Point(200, 46);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new Size(70, 15);
            fullNameLabel.TabIndex = 0;
            fullNameLabel.Text = "Full name: ?";
            // 
            // libraryDbContextBindingSource
            // 
            libraryDbContextBindingSource.DataSource = typeof(Data.LibraryDbContext);
            // 
            // bookBindingSource
            // 
            bookBindingSource.DataSource = typeof(Models.Book);
            // 
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(logoutButton);
            Controls.Add(welcomeLabel);
            Name = "EmployeeMainForm";
            Text = "EmployeeMainForm";
            tabControl1.ResumeLayout(false);
            booksTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).EndInit();
            readersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)readersDataGridView).EndInit();
            blacklistedReadersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)blacklistedReadersDataGridView).EndInit();
            myAccountTabPage.ResumeLayout(false);
            myAccountTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)photoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)libraryDbContextBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        private Button logoutButton;
        private TabControl tabControl1;
        private TabPage booksTabPage;
        private DataGridView booksDataGridView;
        private TabPage readersTabPage;
        private DataGridView readersDataGridView;
        private Button blacklistReaderButton;
        private Button removeReaderFromBlacklistButton;
        private TabPage blacklistedReadersTabPage;
        private PageSetupDialog pageSetupDialog1;
        private DataGridView blacklistedReadersDataGridView;
        private Button removeFromBlacklistButton;
        private Button addBookButton;
        private Button editBookButton;
        private TabPage myAccountTabPage;
        private Label hireDateLabel;
        private Label phoneNumberLabel;
        private Label emailLabel;
        private Label fullNameLabel;
        private BindingSource libraryDbContextBindingSource;
        private BindingSource bookBindingSource;
        private Button editPhotoButton;
        private PictureBox photoBox;
        private Button removePhotoButton;
    }
}