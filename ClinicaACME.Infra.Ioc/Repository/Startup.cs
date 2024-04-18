
using ClinicaACME.Domain.Interfaces;
using ClinicaACME.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaACME.Infra.Ioc.Repository
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceRepository(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, RepositoryPatient>();

            return services;
        }
    }
}
