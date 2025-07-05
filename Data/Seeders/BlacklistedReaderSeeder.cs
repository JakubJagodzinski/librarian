using librarian.Models;

namespace librarian.Data.Seeders
{
    internal class BlacklistedReaderSeeder : ISeeder
    {
        private void ClearTable(LibraryDbContext context)
        {
            var blacklist = context.BlacklistedReaders.ToList();
            context.BlacklistedReaders.RemoveRange(blacklist);
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

                if (!context.BlacklistedReaders.Any())
                {
                    var readers = context.Readers.Take(5).ToList();

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
