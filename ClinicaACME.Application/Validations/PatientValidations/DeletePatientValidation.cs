using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Domain.Common.Exceptions;
using ClinicaACME.Domain.Entities;
using ClinicaACME.Infra.Data.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ClinicaACME.Application.Validations.PatientValidations
{
    public class DeletePatientValidation : AbstractValidator<DeletePatientRequest>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeletePatientValidation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("O campo não pode ser vazio.")
               .NotNull().WithMessage("O campo não pode ser nulo.")
               .MustAsync(async (value, cancellationToken) =>
               {
                   return await _dbContext.Set<Patient>().AnyAsync(x => x.Id == value) ? true : throw new NotFoundException("Paciente não encontrado.");
               });
        }
    }
}
