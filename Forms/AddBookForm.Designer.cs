﻿namespace librarian.Forms
{
    partial class AddBookForm
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
            titleTextBox = new TextBox();
            titleLabel = new Label();
            publishYearNumeric = new NumericUpDown();
            publishYearLabel = new Label();
            pagesNumeric = new NumericUpDown();
            pagesLabel = new Label();
            inStockLabel = new Label();
            inStockNumeric = new NumericUpDown();
            cancelButton = new Button();
            addBookButton = new Button();
            authorComboBox = new ComboBox();
            authorLabel = new Label();
            genresCheckedListBox = new CheckedListBox();
            genresLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)publishYearNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pagesNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inStockNumeric).BeginInit();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(303, 63);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "Pride and Prejudice";
            titleTextBox.Size = new Size(167, 23);
            titleTextBox.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(303, 45);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(33, 15);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Title:";
            // 
            // publishYearNumeric
            // 
            publishYearNumeric.Location = new Point(303, 151);
            publishYearNumeric.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            publishYearNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            publishYearNumeric.Name = "publishYearNumeric";
            publishYearNumeric.Size = new Size(74, 23);
            publishYearNumeric.TabIndex = 2;
            publishYearNumeric.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // publishYearLabel
            // 
            publishYearLabel.AutoSize = true;
            publishYearLabel.Location = new Point(303, 133);
            publishYearLabel.Name = "publishYearLabel";
            publishYearLabel.Size = new Size(74, 15);
            publishYearLabel.TabIndex = 3;
            publishYearLabel.Text = "Publish year:";
            // 
            // pagesNumeric
            // 
            pagesNumeric.Location = new Point(303, 195);
            pagesNumeric.Maximum = new decimal(new int[] { -1530494977, 232830, 0, 0 });
            pagesNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            pagesNumeric.Name = "pagesNumeric";
            pagesNumeric.Size = new Size(74, 23);
            pagesNumeric.TabIndex = 4;
            pagesNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // pagesLabel
            // 
            pagesLabel.AutoSize = true;
            pagesLabel.Location = new Point(303, 177);
            pagesLabel.Name = "pagesLabel";
            pagesLabel.Size = new Size(41, 15);
            pagesLabel.TabIndex = 5;
            pagesLabel.Text = "Pages:";
            // 
            // inStockLabel
            // 
            inStockLabel.AutoSize = true;
            inStockLabel.Location = new Point(303, 221);
            inStockLabel.Name = "inStockLabel";
            inStockLabel.Size = new Size(51, 15);
            inStockLabel.TabIndex = 6;
            inStockLabel.Text = "In stock:";
            // 
            // inStockNumeric
            // 
            inStockNumeric.Location = new Point(303, 239);
            inStockNumeric.Name = "inStockNumeric";
            inStockNumeric.Size = new Size(74, 23);
            inStockNumeric.TabIndex = 7;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(302, 389);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // addBookButton
            // 
            addBookButton.Location = new Point(395, 389);
            addBookButton.Name = "addBookButton";
            addBookButton.Size = new Size(75, 23);
            addBookButton.TabIndex = 9;
            addBookButton.Text = "Add book";
            addBookButton.UseVisualStyleBackColor = true;
            addBookButton.Click += addBookButton_Click;
            // 
            // authorComboBox
            // 
            authorComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            authorComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            authorComboBox.FormattingEnabled = true;
            authorComboBox.Location = new Point(303, 107);
            authorComboBox.Name = "authorComboBox";
            authorComboBox.Size = new Size(167, 23);
            authorComboBox.Sorted = true;
            authorComboBox.TabIndex = 10;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(303, 89);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(47, 15);
            authorLabel.TabIndex = 11;
            authorLabel.Text = "Author:";
            // 
            // genresCheckedListBox
            // 
            genresCheckedListBox.CheckOnClick = true;
            genresCheckedListBox.FormattingEnabled = true;
            genresCheckedListBox.Location = new Point(303, 283);
            genresCheckedListBox.Name = "genresCheckedListBox";
            genresCheckedListBox.Size = new Size(167, 94);
            genresCheckedListBox.TabIndex = 12;
            genresCheckedListBox.ItemCheck += genresCheckedListBox_ItemCheck;
            // 
            // genresLabel
            // 
            genresLabel.AutoSize = true;
            genresLabel.Location = new Point(303, 265);
            genresLabel.Name = "genresLabel";
            genresLabel.Size = new Size(46, 15);
            genresLabel.TabIndex = 13;
            genresLabel.Text = "Genres:";
            // 
            // AddBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(genresLabel);
            Controls.Add(genresCheckedListBox);
            Controls.Add(authorLabel);
            Controls.Add(authorComboBox);
            Controls.Add(addBookButton);
            Controls.Add(cancelButton);
            Controls.Add(inStockNumeric);
            Controls.Add(inStockLabel);
            Controls.Add(pagesLabel);
            Controls.Add(pagesNumeric);
            Controls.Add(publishYearLabel);
            Controls.Add(publishYearNumeric);
            Controls.Add(titleLabel);
            Controls.Add(titleTextBox);
            Name = "AddBookForm";
            Text = "AddBookForm";
            ((System.ComponentModel.ISupportInitialize)publishYearNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)pagesNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)inStockNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTextBox;
        private Label titleLabel;
        private NumericUpDown publishYearNumeric;
        private Label publishYearLabel;
        private NumericUpDown pagesNumeric;
        private Label pagesLabel;
        private Label inStockLabel;
        private NumericUpDown inStockNumeric;
        private Button cancelButton;
        private Button addBookButton;
        private ComboBox authorComboBox;
        private Label authorLabel;
        private CheckedListBox genresCheckedListBox;
        private Label genresLabel;
    }
}