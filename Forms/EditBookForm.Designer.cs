namespace librarian.Forms
{
    partial class EditBookForm
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
            titleLabel = new Label();
            authorLabel = new Label();
            authorComboBox = new ComboBox();
            titleTextBox = new TextBox();
            publishYearNumeric = new NumericUpDown();
            pagesNumeric = new NumericUpDown();
            inStockNumeric = new NumericUpDown();
            publishYearLabel = new Label();
            pagesLabel = new Label();
            inStockLabel = new Label();
            cancelButton = new Button();
            acceptButton = new Button();
            currentTitleLabel = new Label();
            currentAuthorLabel = new Label();
            currentPublishYearLabel = new Label();
            currentPagesLabel = new Label();
            currentInStockLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)publishYearNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pagesNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inStockNumeric).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(320, 80);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(33, 15);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title:";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(320, 124);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(47, 15);
            authorLabel.TabIndex = 1;
            authorLabel.Text = "Author:";
            // 
            // authorComboBox
            // 
            authorComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            authorComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            authorComboBox.FormattingEnabled = true;
            authorComboBox.Location = new Point(320, 142);
            authorComboBox.Name = "authorComboBox";
            authorComboBox.Size = new Size(121, 23);
            authorComboBox.TabIndex = 2;
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(320, 98);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "Pride and Prejudice";
            titleTextBox.Size = new Size(121, 23);
            titleTextBox.TabIndex = 3;
            // 
            // publishYearNumeric
            // 
            publishYearNumeric.Location = new Point(321, 186);
            publishYearNumeric.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            publishYearNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            publishYearNumeric.Name = "publishYearNumeric";
            publishYearNumeric.Size = new Size(120, 23);
            publishYearNumeric.TabIndex = 4;
            publishYearNumeric.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // pagesNumeric
            // 
            pagesNumeric.Location = new Point(321, 230);
            pagesNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            pagesNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            pagesNumeric.Name = "pagesNumeric";
            pagesNumeric.Size = new Size(120, 23);
            pagesNumeric.TabIndex = 5;
            pagesNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // inStockNumeric
            // 
            inStockNumeric.Location = new Point(321, 274);
            inStockNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            inStockNumeric.Name = "inStockNumeric";
            inStockNumeric.Size = new Size(120, 23);
            inStockNumeric.TabIndex = 6;
            // 
            // publishYearLabel
            // 
            publishYearLabel.AutoSize = true;
            publishYearLabel.Location = new Point(321, 168);
            publishYearLabel.Name = "publishYearLabel";
            publishYearLabel.Size = new Size(74, 15);
            publishYearLabel.TabIndex = 7;
            publishYearLabel.Text = "Publish year:";
            // 
            // pagesLabel
            // 
            pagesLabel.AutoSize = true;
            pagesLabel.Location = new Point(321, 212);
            pagesLabel.Name = "pagesLabel";
            pagesLabel.Size = new Size(41, 15);
            pagesLabel.TabIndex = 8;
            pagesLabel.Text = "Pages:";
            // 
            // inStockLabel
            // 
            inStockLabel.AutoSize = true;
            inStockLabel.Location = new Point(320, 256);
            inStockLabel.Name = "inStockLabel";
            inStockLabel.Size = new Size(51, 15);
            inStockLabel.TabIndex = 9;
            inStockLabel.Text = "In stock:";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(287, 320);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // acceptButton
            // 
            acceptButton.Location = new Point(394, 320);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(75, 23);
            acceptButton.TabIndex = 11;
            acceptButton.Text = "Accept";
            acceptButton.UseVisualStyleBackColor = true;
            acceptButton.Click += acceptButton_Click;
            // 
            // currentTitleLabel
            // 
            currentTitleLabel.AutoSize = true;
            currentTitleLabel.Location = new Point(454, 101);
            currentTitleLabel.Name = "currentTitleLabel";
            currentTitleLabel.Size = new Size(56, 15);
            currentTitleLabel.TabIndex = 12;
            currentTitleLabel.Text = "current: ?";
            // 
            // currentAuthorLabel
            // 
            currentAuthorLabel.AutoSize = true;
            currentAuthorLabel.Location = new Point(454, 144);
            currentAuthorLabel.Name = "currentAuthorLabel";
            currentAuthorLabel.Size = new Size(56, 15);
            currentAuthorLabel.TabIndex = 13;
            currentAuthorLabel.Text = "current: ?";
            // 
            // currentPublishYearLabel
            // 
            currentPublishYearLabel.AutoSize = true;
            currentPublishYearLabel.Location = new Point(454, 188);
            currentPublishYearLabel.Name = "currentPublishYearLabel";
            currentPublishYearLabel.Size = new Size(56, 15);
            currentPublishYearLabel.TabIndex = 14;
            currentPublishYearLabel.Text = "current: ?";
            // 
            // currentPagesLabel
            // 
            currentPagesLabel.AutoSize = true;
            currentPagesLabel.Location = new Point(454, 232);
            currentPagesLabel.Name = "currentPagesLabel";
            currentPagesLabel.Size = new Size(56, 15);
            currentPagesLabel.TabIndex = 15;
            currentPagesLabel.Text = "current: ?";
            // 
            // currentInStockLabel
            // 
            currentInStockLabel.AutoSize = true;
            currentInStockLabel.Location = new Point(454, 276);
            currentInStockLabel.Name = "currentInStockLabel";
            currentInStockLabel.Size = new Size(56, 15);
            currentInStockLabel.TabIndex = 16;
            currentInStockLabel.Text = "current: ?";
            // 
            // EditBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(currentInStockLabel);
            Controls.Add(currentPagesLabel);
            Controls.Add(currentPublishYearLabel);
            Controls.Add(currentAuthorLabel);
            Controls.Add(currentTitleLabel);
            Controls.Add(acceptButton);
            Controls.Add(cancelButton);
            Controls.Add(inStockLabel);
            Controls.Add(pagesLabel);
            Controls.Add(publishYearLabel);
            Controls.Add(inStockNumeric);
            Controls.Add(pagesNumeric);
            Controls.Add(publishYearNumeric);
            Controls.Add(titleTextBox);
            Controls.Add(authorComboBox);
            Controls.Add(authorLabel);
            Controls.Add(titleLabel);
            Name = "EditBookForm";
            Text = "EditBookForm";
            ((System.ComponentModel.ISupportInitialize)publishYearNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)pagesNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)inStockNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label authorLabel;
        private ComboBox authorComboBox;
        private TextBox titleTextBox;
        private NumericUpDown publishYearNumeric;
        private NumericUpDown pagesNumeric;
        private NumericUpDown inStockNumeric;
        private Label publishYearLabel;
        private Label pagesLabel;
        private Label inStockLabel;
        private Button cancelButton;
        private Button acceptButton;
        private Label currentTitleLabel;
        private Label currentAuthorLabel;
        private Label currentPublishYearLabel;
        private Label currentPagesLabel;
        private Label currentInStockLabel;
    }
}