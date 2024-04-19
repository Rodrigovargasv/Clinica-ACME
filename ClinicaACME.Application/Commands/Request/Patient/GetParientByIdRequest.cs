using ClinicaACME.Application.Commands.Response.Patient;
using MediatR;
using System.Text.Json.Serialization;

namespace ClinicaACME.Application.Commands.Request.Patient
{
    public class GetParientByIdRequest : IRequest<GetPatientByIdResponse>
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
