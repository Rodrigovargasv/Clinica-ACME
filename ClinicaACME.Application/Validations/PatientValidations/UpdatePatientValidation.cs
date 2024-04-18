
using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Domain.Common.Exceptions;
using ClinicaACME.Domain.Entities;
using ClinicaACME.Infra.Data.Context;
using DocumentValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ClinicaACME.Application.Validations.PatientValidations
{
    public class UpdatePatientValidation : AbstractValidator<UpdatePatientRequest>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdatePatientValidation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("O campo não pode ser vazio.")
               .NotNull().WithMessage("O campo não pode ser nulo.")
               .MustAsync(async (value, cancellationToken) =>
               {
                   return await _dbContext.Set<Patient>().AnyAsync(x => x.Id == value) ? true : throw new NotFoundException("Paciente não encontrado.");
               });

            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("O campo nome não pode ser vazio.")
               .NotNull().WithMessage("O campo nome não pode ser nulo.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("O campo data de nascimento não pode ser vazio.")
                .NotNull().WithMessage("O campo data de nascimento não pode ser nulo.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O campo CPF não pode ser vazio.")
                .NotNull().WithMessage("O campo CPF não pode ser nulo.")
                .Must(value => CpfValidation.Validate(value)).WithMessage("CPF inválido.")
                .MaximumLength(11).WithMessage("o número de CPF deve ter no maxímo 11 digitos.")
                .MustAsync(async (value, cancellationToken) =>
                {
                    return await _dbContext.Set<Patient>()
                    .AnyAsync(x => x.Cpf == value) ? throw new BadRequestException("CPF informado está indiponível.") : true;
                });

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("O campo  sexo não pode ser vazio.")
                .NotNull().WithMessage("O campo sexo não pode ser nulo.")
                .Length(1).WithMessage("O campo sexo deve conter apenas única letra");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("O campo status não pode ser vazio.")
                .NotNull().WithMessage("O campo status não pode ser nulo.");
        }
    }
}
