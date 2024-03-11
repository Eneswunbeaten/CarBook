﻿using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.LocaionQueries;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListTagCloud()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud başarıyla oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(RemoveTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud başarıyla güncellendi");
        }
        [HttpGet("GetTagCloudsByBlogId/{id}")]
        public async Task<IActionResult> GetTagCloudsByBlogId(int id)
        {
            var values=await _mediator.Send(new GetTagCloudsByBlogIdQuery(id));
            return Ok(values);
        }
    }
}
