
using ClinicaACME.Application.Commands.Response.Patient;
using MediatR;

namespace ClinicaACME.Application.Commands.Request.Patient
{
    public class UpdatePatientRequest : IRequest<UpdatePatientResponse>
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Cpf { get; set; }
        public string Gender { get; set; }
        public string? Adress { get; set; }
        public bool? Status { get; set; }
    }
}
