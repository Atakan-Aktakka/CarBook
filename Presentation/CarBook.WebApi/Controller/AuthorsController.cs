using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
          private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var result = await _mediator.Send(new GetAuthorQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AuthorById(int id)
        {
            var result = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yazar başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Yazar başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yazar başarıyla güncellendi");
        }
    }
}