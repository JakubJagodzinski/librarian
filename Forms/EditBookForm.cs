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
            LoadGenres();
            LoadBookData();
        }

        private void LoadGenres()
        {
            using (var db = new LibraryDbContext())
            {
                var genres = db.Genres.ToList();

                genresCheckedListBox.DataSource = genres;
                genresCheckedListBox.DisplayMember = "GenreName";
                genresCheckedListBox.ValueMember = "GenreId";

                genresCheckedListBox.Text = $"New genres ({genres.Count}):";
            }
        }

        private void genresCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int count = genresCheckedListBox.CheckedItems.Count;

            if (e.NewValue == CheckState.Checked)
                count++;
            else if (e.NewValue == CheckState.Unchecked)
                count--;

            genresLabel.Text = $"New genres: {count}";
        }

        private void LoadBookData()
        {
            using var db = new LibraryDbContext();
            var book = db.Books
                .Include(b => b.Author)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .FirstOrDefault(b => b.BookId == _bookId);

            if (book == null)
            {
                MessageBox.Show(this, "Book not found.");
                Close();
                return;
            }

            titleTextBox.Text = book.Title;
            authorComboBox.Text = book.Author?.AuthorFullName ?? "";
            publishYearNumeric.Value = book.PublishedYear;
            pagesNumeric.Value = book.Pages;
            inStockNumeric.Value = book.InStock;

            currentTitleLabel.Text = $"{book.Title}";
            currentAuthorLabel.Text = $"{book.Author?.AuthorFullName ?? "-"}";
            currentPublishYearLabel.Text = $"{book.PublishedYear}";
            currentPagesLabel.Text = $"{book.Pages}";
            currentInStockLabel.Text = $"{book.InStock}";

            var selectedGenreIds = book.BookGenres.Select(bg => bg.GenreId).ToHashSet();
            for (int i = 0; i < genresCheckedListBox.Items.Count; i++)
            {
                var genre = (Genre)genresCheckedListBox.Items[i];
                genresCheckedListBox.SetItemChecked(i, selectedGenreIds.Contains(genre.GenreId));
            }

            var genreNames = book.BookGenres.Select(bg => bg.Genre.GenreName).ToList();
            currentGenresList.Items.Clear();
            foreach (var name in genreNames)
                currentGenresList.Items.Add(name);

            currentGenresLabelHeader.Text = $"Current genres ({genreNames.Count}):";

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
            _employeeMainForm.StartPosition = FormStartPosition.Manual;
            _employeeMainForm.Location = this.Location;
            _employeeMainForm.Show();
            this.Hide();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(authorComboBox.Text))
            {
                MessageBox.Show(this, "Please fill in both the title and author.");
                return;
            }

            using var db = new LibraryDbContext();
            var book = db.Books
            .Include(b => b.BookGenres)
            .FirstOrDefault(b => b.BookId == _bookId);

            if (book == null)
            {
                MessageBox.Show(this, "Book not found.");
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

            book.BookGenres.Clear();

            foreach (var item in genresCheckedListBox.CheckedItems)
            {
                var genre = (Genre)item;
                book.BookGenres.Add(new BookGenre
                {
                    BookId = book.BookId,
                    GenreId = genre.GenreId
                });
            }

            db.SaveChanges();

            MessageBox.Show(this, "Book updated successfully.");

            _employeeMainForm.StartPosition = FormStartPosition.Manual;
            _employeeMainForm.Location = this.Location;
            _employeeMainForm.Show();
            this.Hide();
        }
    }
}
