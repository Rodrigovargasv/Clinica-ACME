using ClinicaACME.Application.Validations.PatientValidations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicaACME.Infra.Ioc.FluentValidation
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceValidationDomains(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreatePatientValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdatePatientValidation>();
            services.AddValidatorsFromAssemblyContaining<GetPatientByIdValidation>();
            services.AddValidatorsFromAssemblyContaining<DeletePatientValidation>();

            return services;
        }
    }
}
