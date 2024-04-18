using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Domain.Common.Exceptions;
using ClinicaACME.Domain.Entities;
using ClinicaACME.Infra.Data.Context;
using DocumentValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ClinicaACME.Application.Validations.PatientValidations
{
    public class CreatePatientValidation : AbstractValidator<CreatePatientRequest>
    {
        private readonly ApplicationDbContext _dbContext;
        public CreatePatientValidation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("O campo não pode ser nulo.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("O campo não pode ser nulo.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("O campo não pode ser nulo.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("O campo não pode ser nulo.")
                .Must(value => CpfValidation.Validate(value)).WithMessage("CPF inválido.")
                .MaximumLength(11).WithMessage("o número de CPF deve ter no maxímo 11 digitos.")
                .MustAsync(async (value, cancellationToken) =>
                {
                    var cpfPatientExist = await _dbContext.Set<Patient>().AnyAsync(x => x.Cpf == value);

                    return cpfPatientExist ? true : throw new BadRequestException("Cpf informado está indiponível.");
                });

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("O campo não pode ser nulo.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("O campo não pode ser vazio.")
                .NotNull().WithMessage("O campo não pode ser nulo.");

        }
    }
}
