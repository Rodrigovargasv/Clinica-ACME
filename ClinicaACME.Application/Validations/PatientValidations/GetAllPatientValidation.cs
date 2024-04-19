
using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Domain.Common.Exceptions;
using ClinicaACME.Domain.Entities;
using ClinicaACME.Infra.Data.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ClinicaACME.Application.Validations.PatientValidations
{
    public class GetAllPatientValidation : AbstractValidator<GetAllPatientRequest>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllPatientValidation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Name)
                .MustAsync(async (value, cancellationToken) =>
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        return await _dbContext.Set<Patient>()
                            .AsNoTracking().AnyAsync(x => x.Name == value) ? true : throw new NotFoundException("Paciente(s) não encontrado");
                    }
                    return true;
                });
        }
    }
}
