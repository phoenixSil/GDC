using Gdc.Api.Repertoires;
using Gdc.Api.Repertoires.Contrats;
using GDE.Api.Datas;
using Microsoft.EntityFrameworkCore;

namespace GDE.Api.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IPointDaccess, PointDaccess>();

            services.AddScoped<IRepertoireDenseignant, RepertoireDenseignant>();
            services.AddScoped<IRepertoireDeNiveau, RepertoireDeNiveau>();
            services.AddScoped<IRepertoireDeMatiere, RepertoireDeMatiere>();
            services.AddScoped<IRepertoireDeCoursGenerique, RepertoireDeCoursGenerique>();

            return services;
        }
    }
}
