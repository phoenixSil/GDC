
using Gdc.Features.Contrats.Repertoires;
using Gdc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MsCommun.Extensions;
using Gdc.Data.Repertoires;

namespace Gdc.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerDbConfiguration<CourDbContext>(configuration);

            services.AddScoped<IPointDaccess, PointDaccess>();
            services.AddScoped<IRepertoireDeCoursGenerique, RepertoireDeCoursGenerique>();
            services.AddScoped<IRepertoireDenseignant, RepertoireDenseignant>();
            services.AddScoped<IRepertoireDeNiveau, RepertoireDeNiveau>();
            services.AddScoped<IRepertoireDeMatiere, RepertoireDeMatiere>();

            return services;
        }
    }
}
