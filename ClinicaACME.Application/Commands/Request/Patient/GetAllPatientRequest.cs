using ClinicaACME.Application.Commands.Response.Patient;
using MediatR;


namespace ClinicaACME.Application.Commands.Request.Patient
{
    public class GetAllPatientRequest : IRequest<IEnumerable<GetAllPatientResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; } 
        public string? Name { get; set;}
    }
}
