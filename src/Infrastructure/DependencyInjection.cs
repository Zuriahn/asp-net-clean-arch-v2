using System.Text;
using Application.Data;
using Application.Services;
using Domain.Primitives;
using Domain.Repository;
using Infrastructure.Persistence;
using Infrastructure.Persistence.JwtConfig;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddSingleton<TokenProvider>();
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtCredentials:Secret"]!)),
                        ValidIssuer = configuration["JwtCredentials:Issuer"],
                        ValidAudience = configuration["JwtCredentials:Audience"],
                        ClockSkew = TimeSpan.FromMinutes(2)
                    };
                });
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            services.AddScoped<IApplicationDbContext>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUnitOfWork>(sp =>
                    sp.GetRequiredService<ApplicationDbContext>());

            services.AddHttpClient<IWeatherService, WeatherService>();

            return services;
        }
    }
}