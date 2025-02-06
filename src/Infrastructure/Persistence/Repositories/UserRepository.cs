using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;

namespace Infrastructure.Persistence.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(User user) => _context.Users.AddAsync(user);
        public void Delete(User user) => _context.Users.Remove(user);
        public void Update(User user) => _context.Users.Update(user);
        public async Task<User?> GetByIdAsync(UserId id) => await _context.Users.SingleOrDefaultAsync(c => c.Id == id);
        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task<User?> GetUserByEmailAndPassword(Email email, Password password) => await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => ((string)u.Email) == email.Value && ((string)u.Password) == password.Value);
    }
}