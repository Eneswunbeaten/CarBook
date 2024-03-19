using CarBook.Application.Features.Mediator.Commands.FreatureAddressCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.FeatureAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ListFooterAddress()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Address başarıyla oluşturukdu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Footer Address başarıyla kaldırıldı");
        }
        [HttpPut]
        public async Task<IActionResult>UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Address başarıyla güncellendi");
        }
    }
}
