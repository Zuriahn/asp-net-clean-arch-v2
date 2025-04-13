using Domain.Exceptions;
using Domain.Primitives;
using Domain.Repository;
using Domain.ValueObjects;
using Domain.Entities;

namespace Application.Authors.Commands
{
    public sealed class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, ErrorOr<Unit>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
        {
            if (!await _authorRepository.ExistsAsync(new AuthorId(command.id)))
            {
                return Errors.Author.NotFound;
            }

            if (PhoneNumber.Create(command.phoneNumber) is not PhoneNumber phoneNumber)
            {
                return Errors.Author.PhoneNumberWithBadFormat;
            }

            if (Address.Create(command.country, command.state, command.street, command.number, command.zipcode) is not Address address)
            {
                return Errors.Author.AddressWithBadFormat;
            }

            var author = Author.UpdateAuthor(command.id, command.name, address, phoneNumber);

            _authorRepository.Update(author);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}