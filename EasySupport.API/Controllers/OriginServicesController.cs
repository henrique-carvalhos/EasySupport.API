using EasySupport.Application.Commands.InsertOriginService;
using EasySupport.Application.Queries.GetOriginServiceById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasySupport.API.Controllers
{
    [Route("api/originservices")]
    [ApiController]
    public class OriginServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OriginServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetOriginServiceByIdQuery(id);

            var result = await _mediator.Send(query);

            if (result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertOriginServiceCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
    }
}
