using librarian.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace librarian.Data.Seeders.Implementations
{
    public class RentalSeeder : ISeeder
    {
        public void Seed(LibraryDbContext context, bool clearTable)
        {
            try
            {
                using var conn = new SqlConnection(context.Database.GetConnectionString());
                conn.Open();

                if (clearTable)
                {
                    using var clearCmd = new SqlCommand("DELETE FROM Rentals", conn);
                    clearCmd.ExecuteNonQuery();
                }

                var readers = context.Readers.Select(r => r.ReaderId).ToList();
                var books = context.Books.Select(b => new { b.BookId, b.InStock }).ToList();
                if (!readers.Any() || !books.Any())
                {
                    MessageBox.Show("No readers or books to seed rentals.", "Seeder Info");
                    return;
                }

                var rng = new Random();
                int rentalsAdded = 0;

                foreach (var readerId in readers)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        var book = books[rng.Next(books.Count)];

                        if (!IsBookAvailable(conn, book.BookId))
                        {
                            continue;
                        }   

                        DateTime rentalDate = DateTime.Today.AddDays(-rng.Next(0, 3 * 365));
                        DateTime plannedReturnDate = rentalDate.AddDays(rng.Next(10, 30));
                        DateTime? returnDate = null;
                        if (rng.NextDouble() < 0.7)
                        {
                            var tmp = rentalDate.AddDays(rng.Next(1, 60));
                            returnDate = tmp > DateTime.Today ? DateTime.Today : tmp;
                        }

                        var insertCmd = new SqlCommand(@"
                        INSERT INTO Rentals (ReaderId, BookId, RentalDate, PlannedReturnDate, ReturnDate)
                        VALUES (@ReaderId, @BookId, @RentalDate, @PlannedReturnDate, @ReturnDate)", conn);

                        insertCmd.Parameters.AddWithValue("@ReaderId", readerId);
                        insertCmd.Parameters.AddWithValue("@BookId", book.BookId);
                        insertCmd.Parameters.AddWithValue("@RentalDate", rentalDate);
                        insertCmd.Parameters.AddWithValue("@PlannedReturnDate", plannedReturnDate);
                        insertCmd.Parameters.AddWithValue("@ReturnDate", (object?)returnDate ?? DBNull.Value);

                        insertCmd.ExecuteNonQuery();
                        rentalsAdded++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rental seeding error: {ex.Message}\nInner: {ex.InnerException?.Message}", "Seeder Error");
            }
        }

        private bool IsBookAvailable(SqlConnection conn, int bookId)
        {
            using var cmd = new SqlCommand(@"
        SELECT CASE 
            WHEN b.InStock > dbo.GetActiveRentalsCount(@BookId) THEN 1
            ELSE 0
        END
        FROM Books b
        WHERE b.BookId = @BookId", conn);

            cmd.Parameters.AddWithValue("@BookId", bookId);
            var result = cmd.ExecuteScalar();
            return (int)(result ?? 0) == 1;
        }
    }

}
