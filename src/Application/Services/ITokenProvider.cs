
using Domain.Entities;

namespace Application.Services
{
    public interface ITokenProvider
    {
        string Create(User user);
    }
}