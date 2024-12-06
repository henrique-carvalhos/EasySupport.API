using EasySupport.Application.Commands.InsertTicketInteraction;
using EasySupport.Application.Queries.GetTicketInteractionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasySupport.API.Controllers
{
    [Route("api/ticketInteractions")]
    [ApiController]
    public class TicketInteractionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicketInteractionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTicketInteractionByIdQuery(id);

            var result = await _mediator.Send(query);

            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertTicketInteractionCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, command);
        }
    }
}
