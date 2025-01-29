namespace Application.Authors.Commands
{
    public record CreateAuthorCommand(
        string name,
        string phoneNumber,
        string country,
        string state,
        string street,
        int number,
        string zipcode
    ) : IRequest<ErrorOr<Guid>>;

}