using Web.API.Extensions;
using Web.API.Middlewares;

namespace Web.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGenWithAuth();
            services.AddTransient<GloblalExceptionHandlingMiddleware>();
            return services;
        }
    }
}