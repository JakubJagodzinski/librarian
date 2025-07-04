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
            Readers = new TabPage();
            readersDataGridView = new DataGridView();
            tabControl1.SuspendLayout();
            booksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksDataGridView).BeginInit();
            Readers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)readersDataGridView).BeginInit();
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
            tabControl1.Controls.Add(Readers);
            tabControl1.Location = new Point(30, 72);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(743, 348);
            tabControl1.TabIndex = 2;
            // 
            // booksTabPage
            // 
            booksTabPage.Controls.Add(booksDataGridView);
            booksTabPage.Location = new Point(4, 24);
            booksTabPage.Name = "booksTabPage";
            booksTabPage.Padding = new Padding(3);
            booksTabPage.Size = new Size(735, 320);
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
            // Readers
            // 
            Readers.Controls.Add(readersDataGridView);
            Readers.Location = new Point(4, 24);
            Readers.Name = "Readers";
            Readers.Padding = new Padding(3);
            Readers.Size = new Size(735, 320);
            Readers.TabIndex = 1;
            Readers.Text = "Readers";
            Readers.UseVisualStyleBackColor = true;
            // 
            // readersDataGridView
            // 
            readersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            readersDataGridView.Location = new Point(0, 0);
            readersDataGridView.Name = "readersDataGridView";
            readersDataGridView.Size = new Size(735, 320);
            readersDataGridView.TabIndex = 0;
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
            Readers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)readersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        private Button logoutButton;
        private TabControl tabControl1;
        private TabPage booksTabPage;
        private DataGridView booksDataGridView;
        private TabPage Readers;
        private DataGridView readersDataGridView;
    }
}