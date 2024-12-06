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
    }
}
