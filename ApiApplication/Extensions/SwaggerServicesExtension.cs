using System.Runtime.CompilerServices;

namespace ApiApplication.APIs.Extensions
{
    public static class SwaggerServicesExtension
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection Services)
        {
            Services.AddSwaggerGen();
            Services.AddEndpointsApiExplorer();

            return Services;
        }

        public static WebApplication AddSwaggerMiddleWares(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
