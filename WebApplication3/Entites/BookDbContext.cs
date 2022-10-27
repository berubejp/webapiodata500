using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Entites
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[] {
                new (){ Id=1, Title="My first book", Author="John Doe" },
                new (){ Id=2, Title="My second book", Author="Jane Doe" }
            });
        }
    }
}
