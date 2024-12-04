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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTicketByIdQuery(id);

            var result = await _mediator.Send(query);

            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
