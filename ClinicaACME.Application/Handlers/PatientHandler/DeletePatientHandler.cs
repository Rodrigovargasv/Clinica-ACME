
using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Domain.Interfaces;
using Mapster;
using MediatR;

namespace ClinicaACME.Application.Handlers.PatientHandler
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientRequest, DeletePatientResponse>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnityOfWork _uow;

        public DeletePatientHandler(IPatientRepository patientRepository, IUnityOfWork uow)
        {
            _patientRepository = patientRepository;
            _uow = uow;
        }

        public async Task<DeletePatientResponse> Handle(DeletePatientRequest request, CancellationToken cancellationToken)
        {
            var patientId = await _patientRepository.GetById(request.Id);

            _patientRepository.Delete(patientId);
            await _uow.Commit();

            return patientId.Adapt<DeletePatientResponse>();
        }
    }
}
