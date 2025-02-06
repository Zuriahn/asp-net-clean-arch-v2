using Application.Users.Dto;

namespace Application.Users.Queries
{
    public record GetUserByEmailAndPasswordQuery(string email, string password) : IRequest<ErrorOr<SessionDto>>;
}