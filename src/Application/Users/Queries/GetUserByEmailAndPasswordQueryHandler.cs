using Domain.Repository;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Exceptions;
using Application.Services;
using Application.Users.Dto;

namespace Application.Users.Queries
{
    internal sealed class GetUserByEmailAndPasswordQueryHandler : IRequestHandler<GetUserByEmailAndPasswordQuery, ErrorOr<SessionDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenProvider _tokenProvider;

        public GetUserByEmailAndPasswordQueryHandler(IUserRepository userRepository, ITokenProvider tokenProvider)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        }

        public async Task<ErrorOr<SessionDto>> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            if (Email.Create(request.email) is not Email email)
            {
                return Errors.User.EmailIsNotValid;
            }

            if (Password.Create(request.password) is not Password password)
            {
                return Errors.User.PasswordIsNotValid;
            }


            User? user = await _userRepository.GetUserByEmailAndPassword(email, password);
            
            if(user is null)
            {
                return Error.NotFound();
            }

            var token = _tokenProvider.Create(user);

            var session = new SessionDto
            (
                user.Id.Value.ToString(),
                user.Name,
                user.LastName,
                user.Email.Value,
                token
            );
            return session;
        }
    }
}