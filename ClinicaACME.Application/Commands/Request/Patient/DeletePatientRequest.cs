
using ClinicaACME.Application.Commands.Response.Patient;
using MediatR;

namespace ClinicaACME.Application.Commands.Request.Patient
{
    public class DeletePatientRequest : IRequest<DeletePatientResponse>
    {
        public int Id { get; set; } 
    }
}
