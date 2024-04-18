using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaACME.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreatePatient")]
        public async Task<CreatePatientResponse> CreatePatient([FromBody] CreatePatientRequest command)
        {
            return await _mediator.Send(command);
        }

    }
}
