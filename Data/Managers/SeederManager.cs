using librarian.Data.Seeders;
using librarian.Data.Seeders.Implementations;

namespace librarian.Data.Managers
{
    public class SeederManager
    {
        private LibraryDbContext _libraryDbContext = null;
        public SeederManager(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public void Seed(bool clearTables)
        {
            var seeders = new List<ISeeder>
            {
                new AuthorSeeder(),
                new BookSeeder(),
                new ReaderSeeder(),
                new BlacklistedReaderSeeder(),
                new GenreSeeder(),
                new EmployeeSeeder(),
                new RentalSeeder(),
                new BookGenreSeeder()
            };

            foreach (var seeder in seeders)
            {
                seeder.Seed(_libraryDbContext, clearTables);
            }
        }
    }
}
