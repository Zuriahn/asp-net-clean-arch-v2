using Domain.Entities;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(UserId id);

        Task<User?> GetUserByEmailAndPassword(Email email, Password password);

        void Add(User author);
        void Update(User author);
        void Delete(User author);
    }
}