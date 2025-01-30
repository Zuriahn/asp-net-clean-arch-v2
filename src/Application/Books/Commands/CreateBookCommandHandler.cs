using Domain.Exceptions;
using Domain.Primitives;
using Domain.Repository;
using Domain.ValueObjects;
using Domain.Entities;

namespace Application.Books.Commands
{
    public sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ErrorOr<Guid>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Guid>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book(new BookId(Guid.NewGuid()), command.title, command.description, command.pages, new AuthorId(command.authorId));

            _bookRepository.Add(book);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return book.Id.Value;
        }
    }
}