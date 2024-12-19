using EasySupport.Application.Commands.DeleteStatusTicket;
using EasySupport.Application.Commands.InsertStatusTicket;
using EasySupport.Application.Commands.UpdateStatusTicket;
using EasySupport.Application.Queries.GetAllStatusTicket;
using EasySupport.Application.Queries.GetStatusTicketById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasySupport.API.Controllers
{
    [Route("api/statustickets")]
    [ApiController]
    public class StatusTicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatusTicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetStatusTicketByIdQuery(id);

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
            var query = new GetAllStatusTicketQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(InsertStatusTicketCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStatusTicketCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdateStatusTicketCommand command)
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