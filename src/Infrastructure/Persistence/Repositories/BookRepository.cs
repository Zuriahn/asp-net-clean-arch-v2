using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;

namespace Infrastructure.Persistence.Repositories
{
    internal sealed class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Book book) => _context.Books.AddAsync(book);
        public void Delete(Book book) => _context.Books.Remove(book);
        public void Update(Book book) => _context.Books.Update(book);
        public async Task<Book?> GetByIdAsync(BookId id) => await _context.Books.SingleOrDefaultAsync(c => c.Id == id);
        public async Task<List<Book>> GetAllAsync() => await _context.Books.ToListAsync();
    }
}