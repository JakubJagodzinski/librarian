using librarian.Data;
using librarian.Models;

namespace librarian.Forms
{
    public partial class AddBookForm : BaseForm
    {
        private BaseForm _employeeMainForm;

        public AddBookForm(BaseForm employeeMainForm)
        {
            InitializeComponent();
            this.Text = "Librarian";

            _employeeMainForm = employeeMainForm;

            LoadAuthors();
            LoadGenres();
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

        private void LoadGenres()
        {
            using (var db = new LibraryDbContext())
            {
                var genres = db.Genres.ToList();
                genresCheckedListBox.DataSource = genres;
                genresCheckedListBox.DisplayMember = "GenreName";
                genresCheckedListBox.ValueMember = "GenreId";
                genresLabel.Text = "Genres (0):";
            }

        }

        private void genresCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int count = genresCheckedListBox.CheckedItems.Count;

            if (e.NewValue == CheckState.Checked)
                count++;
            else if (e.NewValue == CheckState.Unchecked)
                count--;

            genresLabel.Text = $"Genres: ({count})";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _employeeMainForm.Show();
            this.Hide();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            var title = titleTextBox.Text.Trim();
            var authorName = authorComboBox.Text.Trim();
            var selectedGenres = genresCheckedListBox.CheckedItems.Cast<Genre>().ToList();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter the book title.", "Missing Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(authorName))
            {
                MessageBox.Show("Please enter or select an author.", "Missing Author", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new LibraryDbContext())
            {
                var author = db.Authors.FirstOrDefault(a => a.AuthorFullName == authorName);

                if (author == null)
                {
                    author = new Author { AuthorFullName = authorName };
                    db.Authors.Add(author);
                    db.SaveChanges();
                }

                var newBook = new Book
                {
                    Title = titleTextBox.Text.Trim(),
                    AuthorId = author.AuthorId,
                    PublishedYear = (int)publishYearNumeric.Value,
                    Pages = (int)pagesNumeric.Value,
                    InStock = (int)inStockNumeric.Value,
                    BookGenres = selectedGenres.Select(g => new BookGenre
                    {
                        GenreId = g.GenreId
                    }).ToList()
                };

                db.Books.Add(newBook);
                db.SaveChanges();
            }

            MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _employeeMainForm.Show();
            this.Hide();
        }

    }
}
