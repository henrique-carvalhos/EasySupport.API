using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasySupport.API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
