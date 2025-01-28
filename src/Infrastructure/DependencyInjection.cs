using Application.Data;
using Domain.Primitives;
using Domain.Repository;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IAuthorRepository, AuthorRepository>();

            // services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")));
            services.AddDbContext<ReadDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")));
            services.AddDbContext<WriteDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")))
                .AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<WriteDbContext>())
                .AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<WriteDbContext>());

            // services.AddScoped<IApplicationDbContext>(sp =>
            //         sp.GetRequiredService<ApplicationDbContext>());
            // services.AddScoped<IUnitOfWork>(sp =>
            //         sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}