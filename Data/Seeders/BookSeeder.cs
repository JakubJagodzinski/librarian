using librarian.Models;

namespace librarian.Data.Seeders
{
    internal class BookSeeder : ISeeder
    {
        public void Seed(LibraryDbContext context)
        {
            try
            {
                if (!context.Books.Any())
                {
                    var authors = context.Authors.Take(10).ToList();

                    if (!authors.Any())
                    {
                        MessageBox.Show("Brak autorów do utworzenia książek.", "Seeder Info");
                        return;
                    }

                    var books = new List<Book>();

                    foreach (var author in authors)
                    {
                        books.Add(new Book
                        {
                            Title = $"{author.AuthorFullName}'s First Book",
                            AuthorId = author.AuthorId,
                            PublishedYear = 2010 + author.AuthorId % 10,
                            Pages = 100 + author.AuthorId * 10
                        });

                        books.Add(new Book
                        {
                            Title = $"{author.AuthorFullName}'s Second Book",
                            AuthorId = author.AuthorId,
                            PublishedYear = 2015 + author.AuthorId % 5,
                            Pages = 150 + author.AuthorId * 12
                        });
                    }

                    context.Books.AddRange(books);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Book seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }
    }
}
