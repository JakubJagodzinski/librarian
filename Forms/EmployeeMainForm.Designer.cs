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
            welcomeLabel = new Label();
            logoutButton = new Button();
            tabControl1 = new TabControl();
            booksTabPage = new TabPage();
            booksDataGridView = new DataGridView();
            readersTabPage = new TabPage();
            blacklistReaderButton = new Button();
            readersDataGridView = new DataGridView();
            blacklistedReadersTabPage = new TabPage();
            removeFromBlacklistButton = new Button();
            blacklistedReadersDataGridView = new DataGridView();
            pageSetupDialog1 = new PageSetupDialog();
            tabControl1.SuspendLayout();
            booksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).BeginInit();
            readersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)readersDataGridView).BeginInit();
            blacklistedReadersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blacklistedReadersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(342, 29);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(57, 15);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Welcome";
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
            tabControl1.Location = new Point(30, 72);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(743, 328);
            tabControl1.TabIndex = 2;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

            // 
            // booksTabPage
            // 
            booksTabPage.Controls.Add(booksDataGridView);
            booksTabPage.Location = new Point(4, 24);
            booksTabPage.Name = "booksTabPage";
            booksTabPage.Padding = new Padding(3);
            booksTabPage.Size = new Size(735, 300);
            booksTabPage.TabIndex = 0;
            booksTabPage.Text = "Books";
            booksTabPage.UseVisualStyleBackColor = true;
            // 
            // booksDataGridView
            // 
            booksDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksDataGridView.Location = new Point(0, 0);
            booksDataGridView.Name = "booksDataGridView";
            booksDataGridView.Size = new Size(735, 320);
            booksDataGridView.TabIndex = 0;
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
            blacklistedReadersTabPage.Text = "Blacklisted readers";
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
            blacklistedReadersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            blacklistedReadersDataGridView.Location = new Point(0, 0);
            blacklistedReadersDataGridView.Name = "blacklistedReadersDataGridView";
            blacklistedReadersDataGridView.Size = new Size(645, 300);
            blacklistedReadersDataGridView.TabIndex = 0;
            blacklistedReadersDataGridView.CellClick += blacklistedReadersDataGridView_CellClick;
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
            Load += EmployeeMainForm_Load;
            tabControl1.ResumeLayout(false);
            booksTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).EndInit();
            readersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)readersDataGridView).EndInit();
            blacklistedReadersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)blacklistedReadersDataGridView).EndInit();
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
    }
}