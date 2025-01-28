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
            
            var valAddress = new Address(command.address.country, command.address.state, command.address.street, command.address.number, command.address.zipcode).ToString();
            if (Address.Create(valAddress) is not Address address)
            {
                return Errors.Author.AddressWithBadFormat;
            }

            var author = new Author(new AuthorId(Guid.NewGuid()), command.name, address, phoneNumber);

            await _authorRepository.Add(author);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return author.Id.Value;
        }
    }
}