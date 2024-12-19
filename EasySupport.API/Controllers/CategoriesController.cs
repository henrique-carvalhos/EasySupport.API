using Microsoft.AspNetCore.Mvc;
using MediatR;
using EasySupport.Application.Queries.GetCategoryById;
using EasySupport.Application.Commands.InsertCategory;
using EasySupport.Application.Queries.GetAllCategory;
using EasySupport.Application.Commands.UpdateCategory;
using EasySupport.Application.Commands.DeleteCategory;
using Microsoft.AspNetCore.Authorization;

namespace EasySupport.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Client")]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllCategoryQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Client")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoryByIdQuery(id);

            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(InsertCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, UpdateCategoryCommand command)
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
