using librarian.Models;
using Microsoft.EntityFrameworkCore;

namespace librarian.Data
{
    public class LibraryDbContext : DbContext
    {
        private String _connectionString = """Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\kubaj\source\repos\librarian\LibrarianDb.mdf; Integrated Security = True""";

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BlacklistedReader> BlacklistedReaders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }
        public DbSet<ActiveRentalView> ActiveRentalViews { get; set; }

        public object UserCredential { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public String GetConnectionString()
        {
            return _connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Book -> Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            // Rental -> Reader
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Reader)
                .WithMany(reader => reader.Rentals)
                .HasForeignKey(r => r.ReaderId);

            // Rental -> Book
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Book)
                .WithMany()
                .HasForeignKey(r => r.BookId);

            // BookGenre -> Book and Genre
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            // BlacklistedReader -> Reader
            modelBuilder.Entity<BlacklistedReader>()
                .HasOne(br => br.Reader)
                .WithMany(r => r.BlacklistedEntries)
                .HasForeignKey(br => br.ReaderId);

            modelBuilder.Entity<ActiveRentalView>()
                .HasNoKey()
                .ToView("View_ActiveRentals");

            base.OnModelCreating(modelBuilder);
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = Database.GetDbConnection())
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }

    }
}
