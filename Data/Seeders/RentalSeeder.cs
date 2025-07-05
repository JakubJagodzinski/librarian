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

                    for (int i = 0; i < 10; i++)
                    {
                        var reader = readers[random.Next(readers.Count)];
                        var book = books[random.Next(books.Count)];
                        var rentalDate = DateTime.Now.AddDays(-random.Next(1, 60));
                        DateTime plannerReturnDate = rentalDate.AddDays(random.Next(1, 30));
                        DateTime? returnDate = random.Next(0, 2) == 0 ? null : rentalDate.AddDays(random.Next(1, 30));

                        rentals.Add(new Rental
                        {
                            ReaderId = reader.ReaderId,
                            BookId = book.BookId,
                            RentalDate = rentalDate,
                            PlannedReturnDate = plannerReturnDate,
                            ReturnDate = returnDate
                        });
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
