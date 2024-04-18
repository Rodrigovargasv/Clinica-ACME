
using ClinicaACME.Infra.Ioc.Context;
using ClinicaACME.Infra.Ioc.GlobalExceptions;
using ClinicaACME.Infra.Ioc.Repository;
using ClinicaACME.Infra.Ioc.UnityOfWorkDependecy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaACME.Infra.Ioc
{
    public static class StartupBase
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceDBContext(configuration);
            services.AddServiceRepository();
            services.AddServiceUnityOfWork();
            services.AddServiceGlobalExecptions();

            return services;
        }
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config)
        {
            builder.UseGlobalExceptionMiddleware();
            return builder;
        }
    }
}
