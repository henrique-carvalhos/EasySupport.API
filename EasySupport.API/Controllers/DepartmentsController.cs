using EasySupport.Application.Commands.DeleteDepartment;
using EasySupport.Application.Commands.InsertDepartment;
using EasySupport.Application.Commands.UpdateDepartment;
using EasySupport.Application.Queries.GetAllDepartment;
using EasySupport.Application.Queries.GetDepartmentById;
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

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllDepartmentQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDepartmentByIdQuery(id);

            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertDepartmentCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDepartmentCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UpdateDepartmentCommand command)
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
