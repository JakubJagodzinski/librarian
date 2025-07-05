using System.Data;
using librarian.Data;
using librarian.Models;
using Microsoft.EntityFrameworkCore;

namespace librarian.Forms
{
    public partial class EditBookForm : BaseForm
    {
        private int _bookId;

        private BaseForm _employeeMainForm;

        public EditBookForm(BaseForm employeeMainForm, int bookId)
        {
            InitializeComponent();
            this.Text = "Librarian";

            _employeeMainForm = employeeMainForm;
            _bookId = bookId;

            LoadAuthors();
            LoadBookData();
        }

        private void LoadBookData()
        {
            using var db = new LibraryDbContext();
            var book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == _bookId);

            if (book == null)
            {
                MessageBox.Show("Book not found.");
                Close();
                return;
            }

            titleTextBox.Text = book.Title;
            authorComboBox.Text = book.Author?.AuthorFullName ?? "";
            publishYearNumeric.Value = book.PublishedYear;
            pagesNumeric.Value = book.Pages;
            inStockNumeric.Value = book.InStock;

            currentTitleLabel.Text = $"current: {book.Title}";
            currentAuthorLabel.Text = $"current: {book.Author?.AuthorFullName ?? "-"}";
            currentPublishYearLabel.Text = $"current: {book.PublishedYear}";
            currentPagesLabel.Text = $"current: {book.Pages}";
            currentInStockLabel.Text = $"current: {book.InStock}";
        }

        private void LoadAuthors()
        {
            using (var db = new LibraryDbContext())
            {
                var authorNames = db.Authors
                                    .OrderBy(a => a.AuthorFullName)
                                    .Select(a => a.AuthorFullName)
                                    .ToArray();

                authorComboBox.Items.Clear();
                authorComboBox.Items.AddRange(authorNames);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _employeeMainForm.Show();
            this.Hide();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(authorComboBox.Text))
            {
                MessageBox.Show("Please fill in both the title and author.");
                return;
            }

            using var db = new LibraryDbContext();
            var book = db.Books.FirstOrDefault(b => b.BookId == _bookId);

            if (book == null)
            {
                MessageBox.Show("Book not found.");
                return;
            }

            var authorName = authorComboBox.Text;
            var author = db.Authors.FirstOrDefault(a => a.AuthorFullName == authorName);
            if (author == null)
            {
                author = new Author { AuthorFullName = authorName };
                db.Authors.Add(author);
                db.SaveChanges();
            }

            book.Title = titleTextBox.Text;
            book.AuthorId = author.AuthorId;
            book.PublishedYear = (int)publishYearNumeric.Value;
            book.Pages = (int)pagesNumeric.Value;
            book.InStock = (int)inStockNumeric.Value;

            db.SaveChanges();

            MessageBox.Show("Book updated successfully.");

            _employeeMainForm.Show();
            this.Hide();
        }
    }
}
