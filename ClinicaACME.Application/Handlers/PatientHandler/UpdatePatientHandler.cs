
using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Domain.Entities;
using ClinicaACME.Domain.Interfaces;
using Mapster;
using MediatR;

namespace ClinicaACME.Application.Handlers.PatientHandler
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientRequest, UpdatePatientResponse>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnityOfWork _uow;

        public UpdatePatientHandler(IPatientRepository patientRepository, IUnityOfWork unityOfWork)
        {
            _patientRepository = patientRepository;
            _uow = unityOfWork;
        }

        public async Task<UpdatePatientResponse> Handle(UpdatePatientRequest request, CancellationToken cancellationToken)
        {
            var guestId = await _patientRepository.GetById(request.Id);

            if (!string.IsNullOrEmpty(request.Name))
                guestId.Name = request.Name;

            if (!string.IsNullOrEmpty(request.BirthDate.ToString()))
                guestId.BirthDate = request.BirthDate;

            if (!string.IsNullOrEmpty(request.Cpf))
                guestId.Cpf = request.Cpf;

            if (!string.IsNullOrEmpty(request.Gender))
                guestId.Gender = request.Gender;

            if (!string.IsNullOrEmpty(request.Status.ToString()))
                guestId.Status = request.Status;

             _patientRepository.Update(guestId);
            await _uow.Commit();

            return guestId.Adapt<UpdatePatientResponse>();

        }
    }
}
