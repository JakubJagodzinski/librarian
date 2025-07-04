using librarian.Models;

namespace librarian.Seeders
{
    public class AuthorSeeder : ISeeder
    {
        public void Seed(LibraryContext context)
        {
            if (!context.Authors.Any())
            {
                var authors = new List<Author>
                {
                    new Author { AuthorFullName = "John Smith" },
                    new Author { AuthorFullName = "Jane Doe" },
                    new Author { AuthorFullName = "Emily Brown" },
                    new Author { AuthorFullName = "Michael Johnson" },
                    new Author { AuthorFullName = "Sarah Williams" },
                    new Author { AuthorFullName = "David Miller" },
                    new Author { AuthorFullName = "Linda Davis" },
                    new Author { AuthorFullName = "James Wilson" },
                    new Author { AuthorFullName = "Karen Taylor" },
                    new Author { AuthorFullName = "Robert Moore" },
                    new Author { AuthorFullName = "Anna Scott" },
                    new Author { AuthorFullName = "Thomas Anderson" },
                    new Author { AuthorFullName = "Julia Roberts" },
                    new Author { AuthorFullName = "Daniel Evans" },
                    new Author { AuthorFullName = "Sophia Lee" },
                    new Author { AuthorFullName = "Matthew Turner" },
                    new Author { AuthorFullName = "Chloe Harris" },
                    new Author { AuthorFullName = "George Martin" },
                    new Author { AuthorFullName = "Laura Walker" },
                    new Author { AuthorFullName = "William Adams" },
                    new Author { AuthorFullName = "Mark Twain" },
                    new Author { AuthorFullName = "Emily Brontë" },
                    new Author { AuthorFullName = "George Orwell" },
                    new Author { AuthorFullName = "Virginia Woolf" },
                    new Author { AuthorFullName = "Ernest Hemingway" },
                    new Author { AuthorFullName = "J.K. Rowling" },
                    new Author { AuthorFullName = "Isaac Asimov" },
                    new Author { AuthorFullName = "Agatha Christie" }
                };

                context.Authors.AddRange(authors);
                context.SaveChanges();
            }
        }
    }
}