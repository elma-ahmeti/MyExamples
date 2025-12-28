using Microsoft.EntityFrameworkCore;
using Books.Api.Models;

namespace Books.Api.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        // VIEW
        public DbSet<BookWithAuthor> BooksWithAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<BookWithAuthor>()
                .HasNoKey() // because VIEW has no primary key
                .ToView("vw_BooksWithAuthors");
        }
    }
}