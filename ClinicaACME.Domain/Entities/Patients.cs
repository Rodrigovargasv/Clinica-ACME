using ClinicaACME.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaACME.Domain.Entities
{
    public class Patients : EntityBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; } 
        public string Gender { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
    }
}
