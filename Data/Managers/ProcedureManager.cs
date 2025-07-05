using librarian.Data;
using Microsoft.Data.SqlClient;

public class ProcedureManager
{
    private LibraryDbContext _libraryDbContext;

    public ProcedureManager(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public void CreateProcedures()
    {
        CreateRentBookProcedure();
        CreateEndRentalProcedure();
    }

    private void CreateRentBookProcedure()
    {
        var procedureSql = @"
            IF OBJECT_ID('RentBookProcedure', 'P') IS NOT NULL
                DROP PROCEDURE RentBookProcedure;
            
            EXEC('
            CREATE PROCEDURE RentBookProcedure
                @BookId INT,
                @ReaderId INT,
                @RentalDate DATE,
                @PlannedReturnDate DATE
            AS
            BEGIN
                SET NOCOUNT ON;

                IF EXISTS (
                    SELECT 1
                    FROM Books
                    WHERE BookId = @BookId AND InStock > 0
                )
                BEGIN
                    INSERT INTO Rentals (BookId, ReaderId, RentalDate, PlannedReturnDate)
                    VALUES (@BookId, @ReaderId, @RentalDate, @PlannedReturnDate);
                END
                ELSE
                BEGIN
                    RAISERROR(''Book is out of stock.'', 16, 1);
                    RETURN;
                END
            END
            ');
        ";

        using var connection = new SqlConnection(_libraryDbContext.GetConnectionString());
        connection.Open();
        using var command = new SqlCommand(procedureSql, connection);
        command.ExecuteNonQuery();
    }

    private void CreateEndRentalProcedure()
    {
        var procedureSql = @"
            IF OBJECT_ID('EndRentalProcedure', 'P') IS NOT NULL
                DROP PROCEDURE EndRentalProcedure;
    
            EXEC('
            CREATE PROCEDURE EndRentalProcedure
                @RentalId INT,
                @ReturnDate DATETIME
            AS
            BEGIN
                SET NOCOUNT ON;

                IF EXISTS (
                    SELECT 1
                    FROM Rentals
                    WHERE RentalId = @RentalId AND ReturnDate IS NOT NULL
                )
                BEGIN
                    RAISERROR(''This rental is already ended.'', 16, 1);
                    RETURN;
                END

                UPDATE Rentals
                SET ReturnDate = @ReturnDate
                WHERE RentalId = @RentalId;
            END
            ');
        ";

        using var connection = new SqlConnection(_libraryDbContext.GetConnectionString());
        connection.Open();
        using var command = new SqlCommand(procedureSql, connection);
        command.ExecuteNonQuery();
    }

}
