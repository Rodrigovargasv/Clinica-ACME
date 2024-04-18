

using ClinicaACME.Application.Behaviors;
using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Application.Handlers.PatientHandler;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClinicaACME.Infra.Ioc.Meditor
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceMediator(this IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<CreatePatientRequest, CreatePatientResponse>, CreatePatientHandler>();
            services.AddScoped<IRequestHandler<UpdatePatientRequest, UpdatePatientResponse>, UpdatePatientHandler>();
            //services.AddScoped<IRequestHandler<, IEnumerable<>>, >();
            services.AddScoped<IRequestHandler<GetParientByNameRequest, GetPatientByNameResponse>, GetPatientByNameHandler>();
            services.AddScoped<IRequestHandler<DeletePatientRequest, DeletePatientResponse>, DeletePatientHandler>();



            // Configura serviço do MediatR e registra os handlers no assembly atual
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
