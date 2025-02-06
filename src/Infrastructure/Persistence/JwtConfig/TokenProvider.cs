using System.Security.Claims;
using System.Text;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Persistence.JwtConfig
{
    internal sealed class TokenProvider(IConfiguration configuration) : ITokenProvider
    {

        public string Create(User user)
        {
            string secretKey = configuration["JwtCredentials:Secret"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email.Value.ToString()),
                    ]
                ),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:ExpirationInMinutes")),
                SigningCredentials = credentials,
                Issuer = configuration["JwtCredentials:Issuer"],
                Audience = configuration["JwtCredentials:Audience"]
            };
            int expiration = configuration.GetValue<int>("JwtCredentials:ExpirationInMinutes");

            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescription);

            return token;
        }
    }
}