using EasySupport.Application.Commands.InsertSolutionTicket;
using EasySupport.Application.Commands.UpdateSolutionTicket;
using EasySupport.Application.Queries.GetAllSolutionTicket;
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
        public SolutionTicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllSolutionTicketQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
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

        [HttpPost]
        public async Task<IActionResult> Post(InsertSolutionTicketCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateSolutionTicketCommand command)
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
