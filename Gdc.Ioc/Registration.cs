using Gdc.Extensions;
using Gdc.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gdc.InjectionDeDependance
{
    public static  class Registration
    {
        public static IServiceCollection AjoutDeToutesLesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureControllerServices();
            services.ConfigureApplicationServices();

            return services;
        }
    }
}
