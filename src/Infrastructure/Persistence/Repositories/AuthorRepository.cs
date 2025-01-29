using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;

namespace Infrastructure.Persistence.Repositories
{
    internal sealed class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Author author) => _context.Authors.AddAsync(author);
        public void Delete(Author author) => _context.Authors.Remove(author);
        public void Update(Author author) => _context.Authors.Update(author);
        public async Task<Author?> GetByIdAsync(AuthorId id) => await _context.Authors.SingleOrDefaultAsync(c => c.Id == id);
        public async Task<List<Author>> GetAllAsync() => await _context.Authors.ToListAsync();
    }
}