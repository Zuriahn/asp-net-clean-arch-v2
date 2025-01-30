using Domain.Repository;
using Application.Books.Dto;
using Domain.Entities;

namespace Application.Books.Queries
{
    internal sealed class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, ErrorOr<IReadOnlyList<BookDto>>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Book> books = await _bookRepository.GetAllAsync();

            return books.Select(book => new BookDto
            (   
                book.Id.Value,
                book.Title,
                book.Description,
                book.Pages,
                null
            )).ToList();
        }
    }
}