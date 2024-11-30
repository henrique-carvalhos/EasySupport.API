using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasySupport.API.Controllers
{
    [Route("api/originservices")]
    [ApiController]
    public class OriginServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OriginServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
