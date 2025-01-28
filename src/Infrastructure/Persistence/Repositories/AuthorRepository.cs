using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    internal sealed class AuthorRepository : IAuthorRepository
    {
        private readonly DbSet<Author> _authors;
        private readonly WriteDbContext _context;

        public AuthorRepository(WriteDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authors = context.Authors;
        }

        public async Task Add(Author author)
        {
            await _authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Author author)
        {
            _authors.Remove(author);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Author author)
        {
            _authors.Update(author);
            await _context.SaveChangesAsync();
        }
        // public async Task<bool> ExistsAsync(AuthorId id) => await _authors.AnyAsync(author => author.Id == id);
        public async Task<Author?> GetByIdAsync(AuthorId id) => await _authors.SingleOrDefaultAsync(c => c.Id == id);
        public async Task<List<Author>> GetAllAsync() => await _authors.ToListAsync();
    }
}