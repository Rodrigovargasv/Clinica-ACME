using ClinicaACME.Domain.Entities.Commons;

namespace ClinicaACME.Domain.Entities
{
    public class Patient : EntityBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; } 
        public char Gender { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
    }
}
