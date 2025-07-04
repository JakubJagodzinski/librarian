using librarian.Models;

namespace librarian.Seeders
{
    internal class ReaderSeeder : ISeeder
    {
        public void Seed(LibraryContext context)
        {
            try
            {
                if (!context.Readers.Any())
                {
                    var readers = new List<Reader>();
                    for (int i = 1; i <= 20; i++)
                    {
                        readers.Add(new Reader
                        {
                            FullName = $"Reader {i}",
                            Email = $"reader{i}@example.com",
                            PhoneNumber = $"123-456-78{i:00}",
                            DateOfBirth = new DateTime(1980 + i % 20, (i % 12) + 1, (i % 28) + 1)
                        });
                    }

                    context.Readers.AddRange(readers);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Reader seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }
    }
}