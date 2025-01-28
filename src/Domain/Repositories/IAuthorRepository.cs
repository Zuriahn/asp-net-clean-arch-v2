using Domain.Entities;

namespace Domain.Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();

        Task<Author?> GetByIdAsync(AuthorId id);

        Task Add(Author author);
        Task Update(Author author);
        Task Delete(Author author);
    }
}