namespace Application.Users.Dto
{
    public record SessionDto
    (
        string Id,
        string Name,
        string LastName,
        string Email,
        string AccessToken
    );
} 