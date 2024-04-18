
using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Domain.Interfaces;
using Mapster;
using MediatR;

namespace ClinicaACME.Application.Handlers.PatientHandler
{
    public class GetPatientByNameHandler : IRequestHandler<GetParientByNameRequest, GetPatientByNameResponse>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByNameHandler(IPatientRepository patientRepository, IUnityOfWork uow)
        {
            _patientRepository = patientRepository;
        }

        public async Task<GetPatientByNameResponse> Handle(GetParientByNameRequest request, CancellationToken cancellationToken)
        {
            var parientName = await _patientRepository.GetByName(request.Name);

            return parientName.Adapt<GetPatientByNameResponse>();
        }
    }
}
