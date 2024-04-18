
using ClinicaACME.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaACME.Infra.Ioc.Context
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("ClinicaACME");
            });

            return services;
        }
    }
}
