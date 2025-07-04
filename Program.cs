using System.Text;
using librarian.Data;

namespace librarian
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (var context = new LibraryDbContext())
            {
                context.Seed();

                StringBuilder output = new StringBuilder();

                output.AppendLine("Authors:");
                foreach (var author in context.Authors.ToList())
                {
                    output.AppendLine($"- {author.AuthorId}: {author.AuthorFullName}");
                }

                output.AppendLine("\nBooks:");
                foreach (var book in context.Books.ToList())
                {
                    output.AppendLine($"- {book.BookId}: {book.Title} by AuthorId {book.AuthorId}");
                }

                MessageBox.Show(output.ToString(), "Seeded Data");
            }

            Application.Run(new Form1());

        }
    }
}