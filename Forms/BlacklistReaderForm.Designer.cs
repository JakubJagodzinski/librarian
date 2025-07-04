namespace librarian.Forms
{
    partial class BlacklistReaderForm
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
            reasonLabel = new Label();
            reasonTextBox = new TextBox();
            endDateLabel = new Label();
            endDatePicker = new DateTimePicker();
            periodComboBox = new ComboBox();
            periodLabel = new Label();
            blacklistReaderButton = new Button();
            readerNameLabel = new Label();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new Point(288, 75);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new Size(48, 15);
            reasonLabel.TabIndex = 0;
            reasonLabel.Text = "Reason:";
            // 
            // reasonTextBox
            // 
            reasonTextBox.Location = new Point(288, 93);
            reasonTextBox.Multiline = true;
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.Size = new Size(234, 82);
            reasonTextBox.TabIndex = 1;
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Location = new Point(288, 214);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(56, 15);
            endDateLabel.TabIndex = 2;
            endDateLabel.Text = "End date:";
            // 
            // endDatePicker
            // 
            endDatePicker.Location = new Point(288, 232);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(234, 23);
            endDatePicker.TabIndex = 3;
            // 
            // periodComboBox
            // 
            periodComboBox.FormattingEnabled = true;
            periodComboBox.Location = new Point(537, 232);
            periodComboBox.Name = "periodComboBox";
            periodComboBox.Size = new Size(121, 23);
            periodComboBox.TabIndex = 4;
            // 
            // periodLabel
            // 
            periodLabel.AutoSize = true;
            periodLabel.Location = new Point(537, 214);
            periodLabel.Name = "periodLabel";
            periodLabel.Size = new Size(44, 15);
            periodLabel.TabIndex = 5;
            periodLabel.Text = "Period:";
            // 
            // blacklistReaderButton
            // 
            blacklistReaderButton.Location = new Point(399, 354);
            blacklistReaderButton.Name = "blacklistReaderButton";
            blacklistReaderButton.Size = new Size(123, 23);
            blacklistReaderButton.TabIndex = 6;
            blacklistReaderButton.Text = "Blacklist reader";
            blacklistReaderButton.UseVisualStyleBackColor = true;
            blacklistReaderButton.Click += blacklistReaderButton_Click;
            // 
            // readerNameLabel
            // 
            readerNameLabel.AutoSize = true;
            readerNameLabel.Location = new Point(288, 50);
            readerNameLabel.Name = "readerNameLabel";
            readerNameLabel.Size = new Size(67, 15);
            readerNameLabel.TabIndex = 7;
            readerNameLabel.Text = "Reader info";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(288, 354);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // BlacklistReaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelButton);
            Controls.Add(readerNameLabel);
            Controls.Add(blacklistReaderButton);
            Controls.Add(periodLabel);
            Controls.Add(periodComboBox);
            Controls.Add(endDatePicker);
            Controls.Add(endDateLabel);
            Controls.Add(reasonTextBox);
            Controls.Add(reasonLabel);
            Name = "BlacklistReaderForm";
            Text = "BlacklistReaderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label reasonLabel;
        private TextBox reasonTextBox;
        private Label endDateLabel;
        private DateTimePicker endDatePicker;
        private ComboBox periodComboBox;
        private Label periodLabel;
        private Button blacklistReaderButton;
        private Label readerNameLabel;
        private Button cancelButton;
    }
}