namespace librarian.Forms
{
    partial class RegisterForm
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
            registerButton = new Button();
            labelEmail = new Label();
            labelPassword = new Label();
            labelConfirm = new Label();
            emailTextBox = new TextBox();
            roleComboBox = new ComboBox();
            accountType = new Label();
            backButton = new Button();
            fullNameLabel = new Label();
            fullNameTextBox = new TextBox();
            phoneNumberTextBox = new TextBox();
            phoneNumberLabel = new Label();
            passwordTextBox = new TextBox();
            confirmPasswordTextBox = new TextBox();
            datePicker = new DateTimePicker();
            dateLabel = new Label();
            SuspendLayout();
            // 
            // registerButton
            // 
            registerButton.Location = new Point(439, 382);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(75, 23);
            registerButton.TabIndex = 19;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(295, 99);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(39, 15);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(295, 143);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(60, 15);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password:";
            // 
            // labelConfirm
            // 
            labelConfirm.AutoSize = true;
            labelConfirm.Location = new Point(295, 187);
            labelConfirm.Name = "labelConfirm";
            labelConfirm.Size = new Size(107, 15);
            labelConfirm.TabIndex = 3;
            labelConfirm.Text = "Confirm password:";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(295, 117);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "john@example.com";
            emailTextBox.Size = new Size(219, 23);
            emailTextBox.TabIndex = 12;
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(295, 337);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(219, 23);
            roleComboBox.TabIndex = 18;
            roleComboBox.SelectedIndexChanged += RoleComboBox_SelectedIndexChanged;
            // 
            // accountType
            // 
            accountType.AutoSize = true;
            accountType.Location = new Point(295, 319);
            accountType.Name = "accountType";
            accountType.Size = new Size(81, 15);
            accountType.TabIndex = 8;
            accountType.Text = "Account type:";
            // 
            // backButton
            // 
            backButton.BackColor = Color.FromArgb(255, 128, 128);
            backButton.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.System;
            backButton.Location = new Point(295, 382);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 20;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new Point(295, 55);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new Size(62, 15);
            fullNameLabel.TabIndex = 10;
            fullNameLabel.Text = "Full name:";
            // 
            // fullNameTextBox
            // 
            fullNameTextBox.Location = new Point(295, 73);
            fullNameTextBox.Name = "fullNameTextBox";
            fullNameTextBox.PlaceholderText = "John Doe";
            fullNameTextBox.Size = new Size(219, 23);
            fullNameTextBox.TabIndex = 11;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(295, 249);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.PlaceholderText = "123 456 789";
            phoneNumberTextBox.Size = new Size(219, 23);
            phoneNumberTextBox.TabIndex = 15;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(295, 231);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(89, 15);
            phoneNumberLabel.TabIndex = 99;
            phoneNumberLabel.Text = "Phone number:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(295, 161);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "************";
            passwordTextBox.Size = new Size(219, 23);
            passwordTextBox.TabIndex = 13;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(295, 205);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PlaceholderText = "************";
            confirmPasswordTextBox.Size = new Size(219, 23);
            confirmPasswordTextBox.TabIndex = 14;
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(295, 293);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(219, 23);
            datePicker.TabIndex = 16;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(295, 275);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(34, 15);
            dateLabel.TabIndex = 17;
            dateLabel.Text = "Date:";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dateLabel);
            Controls.Add(datePicker);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(phoneNumberLabel);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(fullNameTextBox);
            Controls.Add(fullNameLabel);
            Controls.Add(backButton);
            Controls.Add(accountType);
            Controls.Add(roleComboBox);
            Controls.Add(emailTextBox);
            Controls.Add(labelConfirm);
            Controls.Add(labelPassword);
            Controls.Add(labelEmail);
            Controls.Add(registerButton);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button registerButton;
        private Label labelEmail;
        private Label labelPassword;
        private Label labelConfirm;
        private TextBox emailTextBox;
        private ComboBox roleComboBox;
        private Label accountType;
        private Button backButton;
        private Label fullNameLabel;
        private TextBox fullNameTextBox;
        private TextBox phoneNumberTextBox;
        private Label phoneNumberLabel;
        private TextBox passwordTextBox;
        private TextBox confirmPasswordTextBox;
        private DateTimePicker datePicker;
        private Label dateLabel;
    }
}