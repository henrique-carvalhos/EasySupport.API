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
    }
}
