using librarian.Models;

namespace librarian.Seeders
{
    internal class BookGenreSeeder : ISeeder
    {
        public void Seed(LibraryContext context)
        {
            try
            {
                if (!context.BookGenres.Any())
                {
                    var books = context.Books.Take(10).ToList();
                    var genres = context.Genres.ToList();

                    if (genres.Count < 3)
                    {
                        MessageBox.Show("Za mało gatunków, potrzebne co najmniej 3.", "Seeder Error");
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
