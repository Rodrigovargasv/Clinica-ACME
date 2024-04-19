
using ClinicaACME.Application.Commands.Response.Patient;
using MediatR;
using System.Text.Json.Serialization;

namespace ClinicaACME.Application.Commands.Request.Patient
{
    public class UpdatePatientRequest : IRequest<UpdatePatientResponse>
    {
        [JsonIgnore]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Cpf { get; set; }
        public string Gender { get; set; }
        public string? Adress { get; set; }
        public bool? Status { get; set; }
    }
}
