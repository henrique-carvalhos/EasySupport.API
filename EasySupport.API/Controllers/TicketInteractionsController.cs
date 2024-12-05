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
    }
}
