using librarian.Models;

namespace librarian.Data.Seeders
{
    internal class BookGenreSeeder : ISeeder
    {
        public void Seed(LibraryDbContext context, bool clearTable)
        {
            try
            {
                if (!context.BookGenres.Any())
                {
                    var books = context.Books.Take(10).ToList();
                    var genres = context.Genres.ToList();

                    if (genres.Count < 3)
                    {
                        MessageBox.Show("Not enough genres, required at least 3.", "Seeder Error");
                        return;
                    }

                    var rng = new Random();
                    var bookGenresList = new List<BookGenre>();

                    foreach (var book in books)
                    {
                        var selectedGenres = genres
                            .OrderBy(g => rng.Next())
                            .Take(3)
                            .ToList();

                        foreach (var genre in selectedGenres)
                        {
                            bookGenresList.Add(new BookGenre
                            {
                                BookId = book.BookId,
                                GenreId = genre.GenreId
                            });
                        }
                    }

                    context.BookGenres.AddRange(bookGenresList);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"BookGenre seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }
    }
}
