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
            // btnLogout
            // 
            logoutButton.Location = new Point(686, 25);
            logoutButton.Name = "btnLogout";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Log out";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(logoutButton);
            Controls.Add(welcomeLabel);
            Name = "EmployeeMainForm";
            Text = "EmployeeMainForm";
            Load += EmployeeMainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLabel;
        private Button logoutButton;
    }
}