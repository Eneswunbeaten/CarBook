using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ListService()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis başarıyla oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult>RemoveService(RemoveServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult>UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis başarıyla güncellendi");
        }
    }
}
