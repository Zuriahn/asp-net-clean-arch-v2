namespace Application.Authors.Commands
{
    public record UpdateAuthorCommand(
        Guid id,
        string name,
        string phoneNumber,
        string country,
        string state,
        string street,
        int number,
        string zipcode
    ) : IRequest<ErrorOr<Unit>>;

}