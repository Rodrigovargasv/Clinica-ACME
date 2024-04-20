
using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Domain.Interfaces;
using Mapster;
using MediatR;

namespace ClinicaACME.Application.Handlers.PatientHandler
{
    public class GetAllPatientHandler : IRequestHandler<GetAllPatientRequest, IEnumerable<GetAllPatientResponse>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<GetAllPatientResponse>> Handle(GetAllPatientRequest request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAll(request.Name);

            return patients.Adapt<IEnumerable<GetAllPatientResponse>>();
        }
    }
}
