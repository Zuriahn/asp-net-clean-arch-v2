using Domain.Entities;

namespace Domain.Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();

        Task<Author?> GetByIdAsync(AuthorId id);

        Task<bool> ExistsAsync(AuthorId id);

        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}