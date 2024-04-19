using ClinicaACME.Application.Commands.Request.Patient;
using ClinicaACME.Application.Commands.Response.Patient;
using ClinicaACME.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        [HttpPut("UpdatePatient/{id:int}")]
        public async Task<UpdatePatientResponse> UpdatePatient([FromBody] UpdatePatientRequest command, int id)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpGet("GetAllPatient")]
        public async Task<IEnumerable<GetAllPatientResponse>> GetAllPatient(int page, int pageSize , string name)
        {
            return await _mediator.Send(new GetAllPatientRequest()
            {
                Page = page <= 0 ? 1 : page,
                PageSize = pageSize <= 0 ? 10 : pageSize,
                Name = name
            });
        }

        [HttpGet("GetPatientById/{id:int}")]
        public async Task<GetPatientByIdResponse> GetPatientById(int id)
        {
            return await _mediator.Send(new GetParientByIdRequest() { Id = id });
        }

        [HttpDelete("DeletePatient/{id:int}")]
        public async Task<DeletePatientResponse> DeletePatient(int id)
        {
            return await _mediator.Send(new DeletePatientRequest() { Id = id });
        }

    }
}
