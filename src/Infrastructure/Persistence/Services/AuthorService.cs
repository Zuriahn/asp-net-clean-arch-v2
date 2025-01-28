using Application.Authors.Services;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Models;

namespace Infrastructure.Persistence.Services
{
    internal sealed class AuthorServices : IAuthorService
    {
        private readonly DbSet<AuthorReadModel> _authors;

        public AuthorServices(ReadDbContext context)
        {
            _authors = context.Authors;
        }

        public async Task<List<string>> GetAuthorsByNameAsync(string name)
        {
            return await _authors
                .Where(author => author.Name.Contains(name))
                .Select(author => author.Name)
                .ToListAsync();
        }
    }
}