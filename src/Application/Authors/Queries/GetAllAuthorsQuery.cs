using Application.Authors.Dto;

namespace Application.Authors.Queries
{
    public record GetAllAuthorsQuery() : IRequest<ErrorOr<IReadOnlyList<AuthorDto>>>;
}