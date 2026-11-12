using BookBorrowingCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBorrowingCodeFirst.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorrowingRecord>()
                .HasOne(r => r.Book)
                .WithMany(b => b.BorrowingRecords)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", ISBN = "9780132350884", PublishedYear = 2008 },
                new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", ISBN = "978-0-13-595705-9", PublishedYear = 2019 },
                new Book { Id = 3, Title = "Dế Mèn phiêu lưu ký", Author = "Tô Hoài", ISBN = "0306406152", PublishedYear = 1941 });
        }
    }
}
