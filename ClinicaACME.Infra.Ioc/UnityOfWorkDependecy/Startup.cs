using ClinicaACME.Domain.Interfaces;
using ClinicaACME.Infra.Data.UnityOFWork;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaACME.Infra.Ioc.UnityOfWorkDependecy
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceUnityOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            return services;
        }
    }
}
