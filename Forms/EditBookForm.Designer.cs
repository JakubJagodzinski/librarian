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
            genresCheckedListBox = new CheckedListBox();
            genresLabel = new Label();
            currentGenresList = new ListBox();
            currentGenresLabelHeader = new Label();
            currentTitleLabelHeader = new Label();
            currentAuthorLabelHeader = new Label();
            currentPublishYearLabelHeader = new Label();
            currentPagesLabelHeader = new Label();
            currentInStockLabelHeader = new Label();
            ((System.ComponentModel.ISupportInitialize)publishYearNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pagesNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inStockNumeric).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(308, 36);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(57, 15);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "New title:";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(308, 80);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(72, 15);
            authorLabel.TabIndex = 1;
            authorLabel.Text = "New author:";
            // 
            // authorComboBox
            // 
            authorComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            authorComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            authorComboBox.FormattingEnabled = true;
            authorComboBox.Location = new Point(308, 98);
            authorComboBox.Name = "authorComboBox";
            authorComboBox.Size = new Size(177, 23);
            authorComboBox.TabIndex = 2;
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(308, 54);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "Pride and Prejudice";
            titleTextBox.Size = new Size(177, 23);
            titleTextBox.TabIndex = 3;
            // 
            // publishYearNumeric
            // 
            publishYearNumeric.Location = new Point(309, 142);
            publishYearNumeric.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            publishYearNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            publishYearNumeric.Name = "publishYearNumeric";
            publishYearNumeric.Size = new Size(101, 23);
            publishYearNumeric.TabIndex = 4;
            publishYearNumeric.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // pagesNumeric
            // 
            pagesNumeric.Location = new Point(309, 186);
            pagesNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            pagesNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            pagesNumeric.Name = "pagesNumeric";
            pagesNumeric.Size = new Size(101, 23);
            pagesNumeric.TabIndex = 5;
            pagesNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // inStockNumeric
            // 
            inStockNumeric.Location = new Point(309, 230);
            inStockNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            inStockNumeric.Name = "inStockNumeric";
            inStockNumeric.Size = new Size(101, 23);
            inStockNumeric.TabIndex = 6;
            // 
            // publishYearLabel
            // 
            publishYearLabel.AutoSize = true;
            publishYearLabel.Location = new Point(309, 124);
            publishYearLabel.Name = "publishYearLabel";
            publishYearLabel.Size = new Size(101, 15);
            publishYearLabel.TabIndex = 7;
            publishYearLabel.Text = "New publish year:";
            // 
            // pagesLabel
            // 
            pagesLabel.AutoSize = true;
            pagesLabel.Location = new Point(309, 168);
            pagesLabel.Name = "pagesLabel";
            pagesLabel.Size = new Size(68, 15);
            pagesLabel.TabIndex = 8;
            pagesLabel.Text = "New pages:";
            // 
            // inStockLabel
            // 
            inStockLabel.AutoSize = true;
            inStockLabel.Location = new Point(308, 212);
            inStockLabel.Name = "inStockLabel";
            inStockLabel.Size = new Size(78, 15);
            inStockLabel.TabIndex = 9;
            inStockLabel.Text = "New in stock:";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(303, 367);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // acceptButton
            // 
            acceptButton.Location = new Point(410, 367);
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
            currentTitleLabel.Location = new Point(45, 54);
            currentTitleLabel.Name = "currentTitleLabel";
            currentTitleLabel.Size = new Size(56, 15);
            currentTitleLabel.TabIndex = 12;
            currentTitleLabel.Text = "current: ?";
            // 
            // currentAuthorLabel
            // 
            currentAuthorLabel.AutoSize = true;
            currentAuthorLabel.Location = new Point(45, 98);
            currentAuthorLabel.Name = "currentAuthorLabel";
            currentAuthorLabel.Size = new Size(56, 15);
            currentAuthorLabel.TabIndex = 13;
            currentAuthorLabel.Text = "current: ?";
            // 
            // currentPublishYearLabel
            // 
            currentPublishYearLabel.AutoSize = true;
            currentPublishYearLabel.Location = new Point(45, 142);
            currentPublishYearLabel.Name = "currentPublishYearLabel";
            currentPublishYearLabel.Size = new Size(56, 15);
            currentPublishYearLabel.TabIndex = 14;
            currentPublishYearLabel.Text = "current: ?";
            // 
            // currentPagesLabel
            // 
            currentPagesLabel.AutoSize = true;
            currentPagesLabel.Location = new Point(45, 186);
            currentPagesLabel.Name = "currentPagesLabel";
            currentPagesLabel.Size = new Size(56, 15);
            currentPagesLabel.TabIndex = 15;
            currentPagesLabel.Text = "current: ?";
            // 
            // currentInStockLabel
            // 
            currentInStockLabel.AutoSize = true;
            currentInStockLabel.Location = new Point(45, 230);
            currentInStockLabel.Name = "currentInStockLabel";
            currentInStockLabel.Size = new Size(56, 15);
            currentInStockLabel.TabIndex = 16;
            currentInStockLabel.Text = "current: ?";
            // 
            // genresCheckedListBox
            // 
            genresCheckedListBox.CheckOnClick = true;
            genresCheckedListBox.FormattingEnabled = true;
            genresCheckedListBox.Location = new Point(309, 274);
            genresCheckedListBox.Name = "genresCheckedListBox";
            genresCheckedListBox.Size = new Size(176, 76);
            genresCheckedListBox.Sorted = true;
            genresCheckedListBox.TabIndex = 17;
            genresCheckedListBox.ItemCheck += genresCheckedListBox_ItemCheck;
            // 
            // genresLabel
            // 
            genresLabel.AutoSize = true;
            genresLabel.Location = new Point(308, 256);
            genresLabel.Name = "genresLabel";
            genresLabel.Size = new Size(72, 15);
            genresLabel.TabIndex = 18;
            genresLabel.Text = "New genres:";
            // 
            // currentGenresList
            // 
            currentGenresList.FormattingEnabled = true;
            currentGenresList.ItemHeight = 15;
            currentGenresList.Location = new Point(45, 274);
            currentGenresList.Name = "currentGenresList";
            currentGenresList.Size = new Size(176, 79);
            currentGenresList.TabIndex = 19;
            // 
            // currentGenresLabelHeader
            // 
            currentGenresLabelHeader.AutoSize = true;
            currentGenresLabelHeader.Location = new Point(45, 256);
            currentGenresLabelHeader.Name = "currentGenresLabelHeader";
            currentGenresLabelHeader.Size = new Size(88, 15);
            currentGenresLabelHeader.TabIndex = 20;
            currentGenresLabelHeader.Text = "Current genres:";
            // 
            // currentTitleLabelHeader
            // 
            currentTitleLabelHeader.AutoSize = true;
            currentTitleLabelHeader.Location = new Point(45, 36);
            currentTitleLabelHeader.Name = "currentTitleLabelHeader";
            currentTitleLabelHeader.Size = new Size(73, 15);
            currentTitleLabelHeader.TabIndex = 21;
            currentTitleLabelHeader.Text = "Current title:";
            // 
            // currentAuthorLabelHeader
            // 
            currentAuthorLabelHeader.AutoSize = true;
            currentAuthorLabelHeader.Location = new Point(45, 80);
            currentAuthorLabelHeader.Name = "currentAuthorLabelHeader";
            currentAuthorLabelHeader.Size = new Size(88, 15);
            currentAuthorLabelHeader.TabIndex = 22;
            currentAuthorLabelHeader.Text = "Current author:";
            // 
            // currentPublishYearLabelHeader
            // 
            currentPublishYearLabelHeader.AutoSize = true;
            currentPublishYearLabelHeader.Location = new Point(45, 124);
            currentPublishYearLabelHeader.Name = "currentPublishYearLabelHeader";
            currentPublishYearLabelHeader.Size = new Size(117, 15);
            currentPublishYearLabelHeader.TabIndex = 23;
            currentPublishYearLabelHeader.Text = "Current publish year:";
            // 
            // currentPagesLabelHeader
            // 
            currentPagesLabelHeader.AutoSize = true;
            currentPagesLabelHeader.Location = new Point(45, 168);
            currentPagesLabelHeader.Name = "currentPagesLabelHeader";
            currentPagesLabelHeader.Size = new Size(84, 15);
            currentPagesLabelHeader.TabIndex = 24;
            currentPagesLabelHeader.Text = "Current pages:";
            // 
            // currentInStockLabelHeader
            // 
            currentInStockLabelHeader.AutoSize = true;
            currentInStockLabelHeader.Location = new Point(45, 215);
            currentInStockLabelHeader.Name = "currentInStockLabelHeader";
            currentInStockLabelHeader.Size = new Size(94, 15);
            currentInStockLabelHeader.TabIndex = 25;
            currentInStockLabelHeader.Text = "Current in stock:";
            // 
            // EditBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(currentInStockLabelHeader);
            Controls.Add(currentPagesLabelHeader);
            Controls.Add(currentPublishYearLabelHeader);
            Controls.Add(currentAuthorLabelHeader);
            Controls.Add(currentTitleLabelHeader);
            Controls.Add(currentGenresLabelHeader);
            Controls.Add(currentGenresList);
            Controls.Add(genresLabel);
            Controls.Add(genresCheckedListBox);
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
        private CheckedListBox genresCheckedListBox;
        private Label genresLabel;
        private ListBox currentGenresList;
        private Label currentGenresLabelHeader;
        private Label currentTitleLabelHeader;
        private Label currentAuthorLabelHeader;
        private Label currentPublishYearLabelHeader;
        private Label currentPagesLabelHeader;
        private Label currentInStockLabelHeader;
    }
}