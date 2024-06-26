﻿
using ClinicaACME.Domain.Commons;

namespace ClinicaACME.Application.Commands.Response.Patient
{
    public class GetAllPatientResponse : EntityBase
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; } 
        public string Cpf { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
    }
}
