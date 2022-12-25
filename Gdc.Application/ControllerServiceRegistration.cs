

using Gdc.Application.Services;
using Gdc.Features.Contrats.Services;
using Microsoft.Extensions.DependencyInjection;

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
