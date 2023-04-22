using Microsoft.EntityFrameworkCore;
using ReadersHub.Contracts.Books;
using ReadersHub.Data.Models;
namespace ReadersHub.Data
{
    public class ReadersHubContext: DbContext
    {
        public DbSet<BookDto> Books { get; set; }

        public ReadersHubContext(DbContextOptions<ReadersHubContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.BookDto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
            });
        }
    }
}
