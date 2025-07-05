namespace librarian.Data.Seeders
{
    public interface ISeeder
    {
        void Seed(LibraryDbContext context, bool clearTable);
    }
}
