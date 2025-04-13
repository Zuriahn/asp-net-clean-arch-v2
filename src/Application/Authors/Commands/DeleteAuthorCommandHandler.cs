using Domain.Exceptions;
using Domain.Primitives;
using Domain.Repository;
using Domain.ValueObjects;
using Domain.Entities;

namespace Application.Authors.Commands
{
    public sealed class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, ErrorOr<Unit>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
        {
            if (await _authorRepository.GetByIdAsync(new AuthorId(command.id)) is not Author author)
            {
                return Errors.Author.NotFound;
            }

            _authorRepository.Delete(author);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}