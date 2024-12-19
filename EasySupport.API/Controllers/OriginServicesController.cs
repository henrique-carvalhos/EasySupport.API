using EasySupport.Application.Commands.DeleteOriginService;
using EasySupport.Application.Commands.InsertOriginService;
using EasySupport.Application.Commands.UpdateOriginService;
using EasySupport.Application.Queries.GetAllOriginService;
using EasySupport.Application.Queries.GetOriginServiceById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetOriginServiceByIdQuery(id);

            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllOriginServiceQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(InsertOriginServiceCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteOriginServiceCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdateOriginServiceCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
