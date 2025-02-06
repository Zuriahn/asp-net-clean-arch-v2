using Domain.Exceptions;
using Domain.Primitives;
using Domain.Repository;
using Domain.ValueObjects;
using Domain.Entities;

namespace Application.Users.Commands
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (Email.Create(command.email) is not Email email)
            {
                return Errors.User.EmailIsNotValid;
            }

            if (Password.Create(command.password) is not Password password)
            {
                return Errors.User.PasswordIsNotValid;
            }

            var user = new User(new UserId(Guid.NewGuid()), command.name, command.lastName, email, password);

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}