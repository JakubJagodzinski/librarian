namespace librarian.Forms
{
    partial class PlannedReturnDateForm
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
            plannedReturnDatePicker = new DateTimePicker();
            cancelButton = new Button();
            confirmRentalButton = new Button();
            dateLabel = new Label();
            SuspendLayout();
            // 
            // plannedReturnDatePicker
            // 
            plannedReturnDatePicker.Location = new Point(68, 46);
            plannedReturnDatePicker.Name = "plannedReturnDatePicker";
            plannedReturnDatePicker.Size = new Size(200, 23);
            plannedReturnDatePicker.TabIndex = 0;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(12, 160);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // confirmRentalButton
            // 
            confirmRentalButton.Location = new Point(216, 160);
            confirmRentalButton.Name = "confirmRentalButton";
            confirmRentalButton.Size = new Size(106, 23);
            confirmRentalButton.TabIndex = 2;
            confirmRentalButton.Text = "Confirm rental";
            confirmRentalButton.UseVisualStyleBackColor = true;
            confirmRentalButton.Click += confirmRentalButton_Click;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(68, 28);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(114, 15);
            dateLabel.TabIndex = 3;
            dateLabel.Text = "Planned return date:";
            // 
            // PlannedReturnDateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 195);
            Controls.Add(dateLabel);
            Controls.Add(confirmRentalButton);
            Controls.Add(cancelButton);
            Controls.Add(plannedReturnDatePicker);
            Name = "PlannedReturnDateForm";
            Text = "PlannedReturnDateForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker plannedReturnDatePicker;
        private Button cancelButton;
        private Button confirmRentalButton;
        private Label dateLabel;
    }
}