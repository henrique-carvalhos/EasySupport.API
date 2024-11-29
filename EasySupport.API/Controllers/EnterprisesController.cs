using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasySupport.API.Controllers
{
    [Route("api/enterprises")]
    [ApiController]
    public class EnterprisesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnterprisesController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
