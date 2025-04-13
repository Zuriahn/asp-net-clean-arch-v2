namespace Application.Authors.Commands
{
    public record DeleteAuthorCommand(Guid id) : IRequest<ErrorOr<Unit>>;
}