namespace Application.Authors.Dto
{
    public record AddressDto
    (
        string Country,
        string State,
        string Street,
        int Number,
        string Zipcode
    );
}