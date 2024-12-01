using MediatR;
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
    }
}
