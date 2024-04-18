using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Domain.Entities;
using ClinicaACME.Domain.Interfaces;
using Mapster;
using MediatR;

namespace ClinicaACME.Application.Handlers.PatientHandler
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientRequest, CreatePatientResponse>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnityOfWork _uow;

        public CreatePatientHandler(IPatientRepository patientRepository, IUnityOfWork uow)
        {
            _patientRepository = patientRepository;
            _uow = uow;
        }

        public async Task<CreatePatientResponse> Handle(CreatePatientRequest request, CancellationToken cancellationToken)
        {
            var patient = request.Adapt<Patient>();

            await _patientRepository.Create(patient);
            await _uow.Commit();

            return patient.Adapt<CreatePatientResponse>();    
        }
    }
}
