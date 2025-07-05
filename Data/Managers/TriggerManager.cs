using librarian.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class TriggerManager
{
    private readonly LibraryDbContext _context;

    public TriggerManager(LibraryDbContext context)
    {
        _context = context;
    }

    public void CreateTriggers()
    {
        CreateRentalTrigger();
        CreateReturnTrigger();
    }

    private void CreateRentalTrigger()
    {
        var dropSql = @"
            IF OBJECT_ID('trg_DecreaseBookStockOnRental', 'TR') IS NOT NULL
                DROP TRIGGER trg_DecreaseBookStockOnRental;
        ";

        var createSql = @"
            CREATE TRIGGER trg_DecreaseBookStockOnRental
            ON Rentals
            AFTER INSERT
            AS
            BEGIN
                SET NOCOUNT ON;

                IF EXISTS (
                    SELECT 1
                    FROM Books b
                    INNER JOIN inserted i ON b.BookId = i.BookId
                    WHERE b.InStock <= 0
                )
                BEGIN
                    RAISERROR('Cannot rent a book: no available books in store.', 16, 1);
                    ROLLBACK TRANSACTION;
                    RETURN;
                END

                UPDATE Books
                SET InStock = InStock - 1
                FROM Books
                INNER JOIN inserted i ON Books.BookId = i.BookId;
            END
        ";

        ExecuteTriggerSql(dropSql, createSql);
    }

    private void CreateReturnTrigger()
    {
        var dropSql = @"
            IF OBJECT_ID('trg_IncreaseBookStockOnReturn', 'TR') IS NOT NULL
                DROP TRIGGER trg_IncreaseBookStockOnReturn;
        ";

        var createSql = @"
            CREATE TRIGGER trg_IncreaseBookStockOnReturn
            ON Rentals
            AFTER UPDATE
            AS
            BEGIN
                SET NOCOUNT ON;

                UPDATE Books
                SET InStock = InStock + 1
                FROM Books
                INNER JOIN inserted i ON Books.BookId = i.BookId
                INNER JOIN deleted d ON d.BookId = i.BookId
                WHERE d.ReturnDate IS NULL AND i.ReturnDate IS NOT NULL;
            END
        ";

        ExecuteTriggerSql(dropSql, createSql);
    }

    private void ExecuteTriggerSql(string dropSql, string createSql)
    {
        var connectionString = _context.Database.GetDbConnection().ConnectionString;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var dropCommand = new SqlCommand(dropSql, connection))
                dropCommand.ExecuteNonQuery();

            using (var createCommand = new SqlCommand(createSql, connection))
                createCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}
