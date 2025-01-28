
using Application.Data;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Persistence.WriteConfiguration;

namespace Infrastructure.Persistence.Contexts
{
    internal sealed class WriteDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        public readonly IPublisher _publisher;
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorWriteConfiguration());
            modelBuilder.ApplyConfiguration(new BookWriteConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}