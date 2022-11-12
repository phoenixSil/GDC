

using Gdc.Api.Services;
using Gdc.Api.Services.Contrats;

namespace Gdc.Extensions
{
    public static class ControllerServiceRegistration
    {
        public static IServiceCollection ConfigureControllerServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceDenseignant, ServiceDenseignant>();
            services.AddScoped<IServiceDeCoursGenerique, ServiceDeCoursGenerique>();
            services.AddScoped<IServiceDeMatiere, ServiceDeMatiere>();
            services.AddScoped<IServiceDeNiveau, ServiceDeNiveau>();

            return services;
        }
    }
}
