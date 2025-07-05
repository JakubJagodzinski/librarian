using librarian.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace librarian.Data.Seeders.Implementations
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
                    var inserts = new List<string>();

                    foreach (var book in books)
                    {
                        var selectedGenres = genres
                            .OrderBy(g => rng.Next())
                            .Take(3)
                            .ToList();

                        foreach (var genre in selectedGenres)
                        {
                            inserts.Add($"({book.BookId}, {genre.GenreId})");
                        }
                    }

                    if (inserts.Any())
                    {
                        var insertSql = $@"
                            INSERT INTO BookGenres (BookId, GenreId)
                            VALUES {string.Join(", ", inserts)};
                        ";

                        context.Database.ExecuteSqlRaw(insertSql);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"BookGenre seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }
    }
}
