using EasySupport.Application.Queries.GetSolutionTicketById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasySupport.API.Controllers
{
    [Route("api/solutionTicket")]
    [ApiController]
    public class SolutionTicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SolutionTicketsController(IMediator mediator )
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSolutionTicketByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
