using librarian.Models;

namespace librarian.Seeders
{
    internal class BlacklistedReaderSeeder : ISeeder
    {
        public void Seed(LibraryContext context)
        {
            try
            {
                if (!context.BlacklistedReaders.Any())
                {
                    var readers = context.Readers.Take(5).ToList(); // Weź pierwszych 5 czytelników

                    var blacklist = readers.Select((reader, index) => new BlacklistedReader
                    {
                        ReaderId = reader.ReaderId,
                        Reason = $"Reason #{index + 1}",
                        BlacklistedDate = DateTime.Now.AddDays(-10 * (index + 1)),
                        RemovalDate = index % 2 == 0 ? null : DateTime.Now.AddDays(-1)
                    }).ToList();

                    context.BlacklistedReaders.AddRange(blacklist);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Blacklisted seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }
    }
}
