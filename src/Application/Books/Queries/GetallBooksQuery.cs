using Application.Books.Dto;

namespace Application.Books.Queries
{
    public record GetAllBooksQuery() : IRequest<ErrorOr<IReadOnlyList<BookDto>>>;
}