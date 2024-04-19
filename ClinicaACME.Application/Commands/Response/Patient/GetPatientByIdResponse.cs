
using ClinicaACME.Domain.Commons;

namespace ClinicaACME.Application.Commands.Response.Patient
{
    public class GetPatientByIdResponse : EntityBase
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public char Gender { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
    }
}
