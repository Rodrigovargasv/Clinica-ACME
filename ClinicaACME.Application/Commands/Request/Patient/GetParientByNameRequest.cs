using ClinicaACME.Application.Commands.Response.Patient;
using MediatR;

namespace ClinicaACME.Application.Commands.Request.Patient
{
    public class GetParientByNameRequest : IRequest<GetPatientByNameResponse>
    {
        public string Name { get; set; }
    }
}
