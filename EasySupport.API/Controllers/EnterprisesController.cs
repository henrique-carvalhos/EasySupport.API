﻿using EasySupport.Application.Commands.InsertEnterprise;
using EasySupport.Application.Queries.GetAllEnterprise;
using EasySupport.Application.Queries.GetEntreprise;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetEntrepriseByIdQuery(id);

            var result  = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var query = new GetAllEnterpriseQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertEnterpriseCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, command);
        }
    }
}
