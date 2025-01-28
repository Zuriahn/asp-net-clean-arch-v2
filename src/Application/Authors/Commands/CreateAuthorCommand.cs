namespace Application.Authors.Commands
{
    public record CreateAuthorCommand(
        string name,
        string phoneNumber,
        AddressWriteCommand address
    ) : IRequest<ErrorOr<Guid>>;

    public record AddressWriteCommand
    (
        string country,
        string state,
        string street,
        int number,
        string zipcode
    );
}