using Microsoft.EntityFrameworkCore;
using MovieTicketDatabaseFirst.Models;

namespace MovieTicketDatabaseFirst.Data
{
    public class MovieTicketDbContext : DbContext
    {
        public MovieTicketDbContext(DbContextOptions<MovieTicketDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.Tickets)
                .HasForeignKey(t => t.MovieId);
        }
    }
}
