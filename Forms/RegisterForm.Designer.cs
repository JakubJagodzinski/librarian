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
            SuspendLayout();
            // 
            // registerButton
            // 
            registerButton.Location = new Point(386, 373);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(75, 23);
            registerButton.TabIndex = 0;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(316, 133);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(39, 15);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "email:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(316, 177);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(60, 15);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "password:";
            // 
            // labelConfirm
            // 
            labelConfirm.AutoSize = true;
            labelConfirm.Location = new Point(316, 221);
            labelConfirm.Name = "labelConfirm";
            labelConfirm.Size = new Size(105, 15);
            labelConfirm.TabIndex = 3;
            labelConfirm.Text = "confirm password:";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(316, 151);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "john@example.com";
            emailTextBox.Size = new Size(121, 23);
            emailTextBox.TabIndex = 4;
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(316, 327);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(121, 23);
            roleComboBox.TabIndex = 7;
            // 
            // accountType
            // 
            accountType.AutoSize = true;
            accountType.Location = new Point(316, 309);
            accountType.Name = "accountType";
            accountType.Size = new Size(79, 15);
            accountType.TabIndex = 8;
            accountType.Text = "account type:";
            // 
            // backButton
            // 
            backButton.Location = new Point(280, 373);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 9;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new Point(316, 89);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new Size(60, 15);
            fullNameLabel.TabIndex = 10;
            fullNameLabel.Text = "full name:";
            // 
            // fullNameTextBox
            // 
            fullNameTextBox.Location = new Point(316, 107);
            fullNameTextBox.Name = "fullNameTextBox";
            fullNameTextBox.PlaceholderText = "John Doe";
            fullNameTextBox.Size = new Size(121, 23);
            fullNameTextBox.TabIndex = 11;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(316, 283);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.PlaceholderText = "123 456 789";
            phoneNumberTextBox.Size = new Size(121, 23);
            phoneNumberTextBox.TabIndex = 12;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(316, 265);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(89, 15);
            phoneNumberLabel.TabIndex = 13;
            phoneNumberLabel.Text = "phone number:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(316, 195);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "************";
            passwordTextBox.Size = new Size(121, 23);
            passwordTextBox.TabIndex = 14;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(316, 239);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PlaceholderText = "************";
            confirmPasswordTextBox.Size = new Size(121, 23);
            confirmPasswordTextBox.TabIndex = 15;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}