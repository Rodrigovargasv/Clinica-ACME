
using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Domain.Interfaces;
using Mapster;
using MediatR;

namespace ClinicaACME.Application.Handlers.PatientHandler
{
    public class GetPatientByIdHandler : IRequestHandler<GetParientByIdRequest, Commands.Response.Patient.GetPatientByIdResponse>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByIdHandler(IPatientRepository patientRepository, IUnityOfWork uow)
        {
            _patientRepository = patientRepository;
        }

        public async Task<GetPatientByIdResponse> Handle(GetParientByIdRequest request, CancellationToken cancellationToken)
        {
            var parientName = await _patientRepository.GetById(request.Id);

            return parientName.Adapt<Commands.Response.Patient.GetPatientByIdResponse>();
        }
    }
}
