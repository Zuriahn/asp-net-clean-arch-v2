namespace Application.Users.Dto
{
    public record UserDto
    (
        Guid Id,
        string Name,
        string LastName,
        string? Email,
        string? Password
    );
} 