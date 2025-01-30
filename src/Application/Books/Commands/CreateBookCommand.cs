namespace Application.Books.Commands
{
    public record CreateBookCommand(
        string title,
        string description,
        int pages,
        Guid authorId
    ) : IRequest<ErrorOr<Guid>>;

}