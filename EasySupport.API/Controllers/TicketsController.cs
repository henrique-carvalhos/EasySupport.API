using EasySupport.Application.Commands.DeleteTicket;
using EasySupport.Application.Commands.InsertTicket;
using EasySupport.Application.Commands.UpdateTicket;
using EasySupport.Application.Queries.GetAllTicket;
using EasySupport.Application.Queries.GetTicketById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasySupport.API.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllTicketQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTicketByIdQuery(id);

            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertTicketCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTicketCommand(id));

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateTicketCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok();
        }
    }
}
