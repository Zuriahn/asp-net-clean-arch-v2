using Domain.Entities;

namespace Domain.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(BookId id);

        void Add(Book author);
        void Update(Book author);
        void Delete(Book author);
    }
}