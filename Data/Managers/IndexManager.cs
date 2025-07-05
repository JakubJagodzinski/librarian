using librarian.Data;
using Microsoft.Data.SqlClient;

public class IndexManager
{
    private readonly LibraryDbContext _context;

    public IndexManager(LibraryDbContext context)
    {
        _context = context;
    }

    public void CreateIndexes()
    {
        CreateIndex("IX_Rentals_ReturnDate", "Rentals", "ReturnDate");
        CreateCompositeIndex("IX_Rentals_ReaderId_ReturnDate", "Rentals", "ReaderId, ReturnDate");
    }

    private void CreateIndex(string indexName, string tableName, string columnName)
    {
        var sql = $@"
            IF NOT EXISTS (
                SELECT 1 FROM sys.indexes
                WHERE name = '{indexName}' AND object_id = OBJECT_ID('{tableName}')
            )
            BEGIN
                CREATE INDEX {indexName} ON {tableName}({columnName});
            END";

        using var connection = new SqlConnection(_context.GetConnectionString());
        connection.Open();
        using var command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }

    private void CreateCompositeIndex(string indexName, string tableName, string columns)
    {
        var sql = $@"
            IF NOT EXISTS (
                SELECT 1 FROM sys.indexes
                WHERE name = '{indexName}' AND object_id = OBJECT_ID('{tableName}')
            )
            BEGIN
                CREATE INDEX {indexName} ON {tableName}({columns});
            END";

        using var connection = new SqlConnection(_context.GetConnectionString());
        connection.Open();
        using var command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }
}
