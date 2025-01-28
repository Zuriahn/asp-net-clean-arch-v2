namespace Application.Authors.Dto
{
    public record AuthorDto
    (
        Guid Id,
        string Name,
        string PhoneNumber,
        AddressDto Address
    );
}