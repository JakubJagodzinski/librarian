using librarian.Models;

namespace librarian.Data.Seeders.Implementations
{
    internal class BookSeeder : ISeeder
    {
        private void ClearTable(LibraryDbContext context)
        {
            var bookGenres = context.BookGenres.ToList();
            context.BookGenres.RemoveRange(bookGenres);

            var books = context.Books.ToList();
            context.Books.RemoveRange(books);

            context.SaveChanges();
        }

        public void Seed(LibraryDbContext context, bool clearTable)
        {
            try
            {
                if (clearTable)
                {
                    ClearTable(context);
                }

                if (!context.Books.Any())
                {
                    var authors = context.Authors.Take(10).ToList();

                    if (!authors.Any())
                    {
                        MessageBox.Show("No authors.", "Seeder Info");
                        return;
                    }

                    var books = new List<Book>();

                    var random = new Random();

                    foreach (var author in authors)
                    {
                        books.Add(new Book
                        {
                            Title = $"{author.AuthorFullName}'s First Book",
                            AuthorId = author.AuthorId,
                            PublishedYear = 2010 + author.AuthorId % 10,
                            Pages = random.Next(500) + 100,
                            InStock = random.Next(10)
                        });

                        books.Add(new Book
                        {
                            Title = $"{author.AuthorFullName}'s Second Book",
                            AuthorId = author.AuthorId,
                            PublishedYear = 2015 + author.AuthorId % 5,
                            Pages = random.Next(500) + 100,
                            InStock = random.Next(10)
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
