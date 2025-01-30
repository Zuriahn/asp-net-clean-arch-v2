using Application.Authors.Dto;

namespace Application.Books.Dto
{
    public record BookDto
    (
        Guid Id,
        string Title,
        string Description,
        int Pages,
        AuthorDto? Author
    );
}