using Domain.Entities;

namespace Application.Users.Commands
{
    public record CreateUserCommand
    ( 
        string name,
        string lastName,
        string email,
        string password
    ) : IRequest<ErrorOr<User>>;
}