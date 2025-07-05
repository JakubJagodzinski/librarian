using librarian.Models;

namespace librarian.Data.Seeders
{
    public class RentalSeeder : ISeeder
    {
        private void ClearTable(LibraryDbContext context)
        {
            var rentals = context.Rentals.ToList();
            context.Rentals.RemoveRange(rentals);
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

                if (!context.Rentals.Any())
                {
                    var readers = context.Readers.ToList();
                    var books = context.Books.ToList();

                    if (!readers.Any() || !books.Any())
                    {
                        MessageBox.Show("No readers or books to create rentals.", "Seeder Info");
                        return;
                    }

                    var random = new Random();
                    var rentals = new List<Rental>();

                    foreach (var reader in readers)
                    {
                        int rentalCount = 50;

                        for (int i = 0; i < rentalCount; i++)
                        {
                            var book = books[random.Next(books.Count)];

                            // Rental date: from 3 years ago up to today
                            DateTime rentalDate = DateTime.Today.AddDays(-random.Next(0, 3 * 365));

                            // Planned return date: 10-30 days after rental
                            DateTime plannedReturnDate = rentalDate.AddDays(random.Next(10, 31));

                            // Return date: maybe returned, maybe not
                            DateTime? returnDate = null;
                            if (random.NextDouble() < 0.7) // 70% chance it was returned
                            {
                                // Returned 1-60 days after rental
                                returnDate = rentalDate.AddDays(random.Next(1, 61));
                                if (returnDate > DateTime.Today)
                                    returnDate = DateTime.Today; // no return dates in future
                            }

                            rentals.Add(new Rental
                            {
                                ReaderId = reader.ReaderId,
                                BookId = book.BookId,
                                RentalDate = rentalDate,
                                PlannedReturnDate = plannedReturnDate,
                                ReturnDate = returnDate
                            });
                        }
                    }

                    context.Rentals.AddRange(rentals);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rental seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }
    }
}
