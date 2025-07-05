using librarian.Models;

namespace librarian.Data.Seeders
{
    internal class ReaderSeeder : ISeeder
    {
        private void ClearTable(LibraryDbContext context)
        {
            var existingReaders = context.Readers.ToList();
            var relatedCredentials = context.UserCredentials
                .Where(c => c.ReaderId != null)
                .ToList();

            context.UserCredentials.RemoveRange(relatedCredentials);
            context.Readers.RemoveRange(existingReaders);
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

                if (!context.Readers.Any())
                {
                    var readers = new List<Reader>();
                    var credentials = new List<UserCredentials>();

                    for (int i = 1; i <= 20; i++)
                    {
                        var reader = new Reader
                        {
                            FullName = $"Reader {i}",
                            Email = $"reader{i}@librarian.com",
                            PhoneNumber = $"123-456-78{i:00}",
                            DateOfBirth = new DateTime(1980 + i % 20, i % 12 + 1, i % 28 + 1)
                        };

                        readers.Add(reader);

                        credentials.Add(new UserCredentials
                        {
                            Email = reader.Email,
                            PasswordHash = PasswordHasher.Hash("123"),
                            Reader = reader
                        });
                    }

                    context.Readers.AddRange(readers);
                    context.UserCredentials.AddRange(credentials);
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
