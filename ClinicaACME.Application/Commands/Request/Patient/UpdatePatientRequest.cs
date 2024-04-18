
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
        public char? Gender { get; set; }
        public string? Adress { get; set; }
        public string? Status { get; set; }
    }
}
