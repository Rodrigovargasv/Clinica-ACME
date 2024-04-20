using ClinicaACME.Application.Commands.Response.Patient;
using MediatR;


namespace ClinicaACME.Application.Commands.Request.Patient
{
    public class GetAllPatientRequest : IRequest<IEnumerable<GetAllPatientResponse>>
    {
        public string? Name { get; set;}
    }
}
