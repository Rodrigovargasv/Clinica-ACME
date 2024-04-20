
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

            int teste = 0;

            RuleFor(x => x.Id)
               .MustAsync(async (value, cancellationToken) =>
               {
                   return await _dbContext.Set<Patient>().AnyAsync(x => x.Id == value) ? true : throw new NotFoundException("Paciente não encontrado.");

               });


            RuleFor(x => x.Cpf)
                .Must(value =>
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        return CpfValidation.Validate(value) ? true : throw new BadRequestException("CPF inválido.");
                    }
                    return true;
                }).WithMessage("CPF inválido.");
                //.MustAsync(async (value, cancellationToken) =>
                //{
                //    return await _dbContext.Set<Patient>().AsNoTracking().AnyAsync(x => x.Cpf == value)  
                //        ? throw new BadRequestException("CPF informado está indiponível.") : true;

                //});

            RuleFor(x => x)
              .MustAsync(async (value, context) =>
              {
                  return await _dbContext.Set<Patient>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Cpf == value.Cpf && x.Id == value.Id && x.Cpf == value.Cpf) == null 
                        ? throw new BadRequestException("CPF informado está indiponível.") : true;
              });
        }

    }
}
