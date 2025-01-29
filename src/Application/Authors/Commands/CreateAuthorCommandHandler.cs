using Domain.Exceptions;
using Domain.Primitives;
using Domain.Repository;
using Domain.ValueObjects;
using Domain.Entities;

namespace Application.Authors.Commands
{
    public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, ErrorOr<Guid>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Guid>> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            if (PhoneNumber.Create(command.phoneNumber) is not PhoneNumber phoneNumber)
            {
                return Errors.Author.PhoneNumberWithBadFormat;
            }
            
            if (Address.Create(command.country, command.state, command.street, command.number, command.zipcode) is not Address address)
            {
                return Errors.Author.AddressWithBadFormat;
            }

            var author = new Author(new AuthorId(Guid.NewGuid()), command.name, address, phoneNumber);

            _authorRepository.Add(author);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return author.Id.Value;
        }
    }
}