using ClinicaACME.Domain.Commons;

namespace ClinicaACME.Domain.Entities
{
    public class Patient : EntityBase
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Cpf { get; set; } 
        public string Gender { get; set; }
        public string Adress { get; set; }
        public bool? Status { get; set; } = false;
    }
}
