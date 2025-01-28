
using Infrastructure.Config;
using Infrastructure.Persistence.Models;
using Infrastructure.Persistence.ReadConfiguration;

namespace Infrastructure.Persistence.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {

        public DbSet<AuthorReadModel> Authors { get; set; }
        public DbSet<BookReadModel> Books { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorReadConfiguration());
            modelBuilder.ApplyConfiguration(new BookReadConfiguration());
        }
    }
}