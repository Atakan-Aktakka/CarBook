using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagCloudsController : ControllerBase
    {
          private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var result = await _mediator.Send(new GetTagCloudQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TagCloudById(int id)
        {
            var result = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(result);
        }
        [HttpGet("GetTagCloudByBlogId/{id}")]
        public async Task<IActionResult> TagCloudByBlogId(int id)
        {
            var result = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Etiket başarıyla silindi");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket başarıyla güncellendi");
        }
    }
}