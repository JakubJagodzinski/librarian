using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace librarian.Data.Views
{
    public class ViewManager
    {
        private readonly LibraryDbContext _context;

        public ViewManager(LibraryDbContext context)
        {
            _context = context;
        }

        public void CreateViews()
        {
            CreateActiveRentalsView();
        }

        private void CreateActiveRentalsView()
        {
            var sql = @"
                CREATE VIEW View_ActiveRentals AS
                SELECT 
                    r.RentalId,
                    r.BookId,
                    b.Title AS BookTitle,
                    r.ReaderId,
                    r.RentalDate,
                    r.PlannedReturnDate
                FROM Rentals r
                JOIN Books b ON b.BookId = r.BookId
                WHERE r.ReturnDate IS NULL;
            ";

            _context.Database.ExecuteSqlRaw(sql);
        }

    }
}
