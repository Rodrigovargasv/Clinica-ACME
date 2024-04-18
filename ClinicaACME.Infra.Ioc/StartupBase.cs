
using ClinicaACME.Infra.Ioc.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaACME.Infra.Ioc
{
    public static class StartupBase
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceDBContext(configuration);

            return services;
        }
    }
}
