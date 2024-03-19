using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Interfaces;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ListTestimonial()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetTestimonial(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Testimonial başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult>RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Testimonial başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult>UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Testimonial başarıyla güncellendi");
        }
    }
}
