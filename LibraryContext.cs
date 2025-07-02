using librarian.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace librarian
{
    public class LibraryContext : DbContext
    {
        // DbSet properties for your models
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BlacklistedReader> BlacklistedReaders { get; set; }

        // Configure the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("""Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\kubaj\source\repos\librarian\Database1.mdf; Integrated Security = True""");
        }

        // Configure model relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacja Book -> Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            // Relacja Rental -> Reader
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Reader)
                .WithMany(reader => reader.Rentals)
                .HasForeignKey(r => r.ReaderId);

            // Relacja Rental -> Book
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Book)
                .WithMany()
                .HasForeignKey(r => r.BookId);

            // Relacja BookGenre -> Book i Genre
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany()
                .HasForeignKey(bg => bg.GenreId);

            // Relacja BlacklistedReader -> Reader
            modelBuilder.Entity<BlacklistedReader>()
                .HasOne(br => br.Reader)
                .WithOne()
                .HasForeignKey<BlacklistedReader>(br => br.ReaderId);

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
