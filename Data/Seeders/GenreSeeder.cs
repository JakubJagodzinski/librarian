using librarian.Models;

namespace librarian.Data.Seeders
{
    internal class GenreSeeder : ISeeder
    {
        public void Seed(LibraryDbContext context)
        {
            try
            {
                if (!context.Genres.Any())
                {
                    var genres = new List<Genre>
                    {
                        new Genre { GenreName = "Fantasy" },
                        new Genre { GenreName = "Science Fiction" },
                        new Genre { GenreName = "Mystery" },
                        new Genre { GenreName = "Thriller" },
                        new Genre { GenreName = "Romance" },
                        new Genre { GenreName = "Horror" },
                        new Genre { GenreName = "Historical" },
                        new Genre { GenreName = "Biography" },
                        new Genre { GenreName = "Self-Help" },
                        new Genre { GenreName = "Non-Fiction" },
                        new Genre { GenreName = "Adventure" },
                        new Genre { GenreName = "Drama" },
                        new Genre { GenreName = "Poetry" },
                        new Genre { GenreName = "Comics" },
                        new Genre { GenreName = "Young Adult" }
                    };

                    context.Genres.AddRange(genres);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Genre seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }
    }
}
