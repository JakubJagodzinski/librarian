using librarian.Data;
using Microsoft.Data.SqlClient;

public class FunctionManager
{
    private readonly LibraryDbContext _context;

    public FunctionManager(LibraryDbContext context)
    {
        _context = context;
    }

    public void CreateFunctions()
    {
        CreateGetActiveRentalsCountFunction();
    }

    private void CreateGetActiveRentalsCountFunction()
    {
        var sql = @"
            IF OBJECT_ID('GetActiveRentalsCount', 'FN') IS NOT NULL
                DROP FUNCTION GetActiveRentalsCount;

            EXEC('
                CREATE FUNCTION GetActiveRentalsCount(@BookId INT)
                RETURNS INT
                AS
                BEGIN
                    DECLARE @Count INT;

                    SELECT @Count = COUNT(*)
                    FROM Rentals
                    WHERE BookId = @BookId AND ReturnDate IS NULL;

                    RETURN @Count;
                END
            ');
        ";

        using var connection = new SqlConnection(_context.GetConnectionString());
        connection.Open();
        using var command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }
}
