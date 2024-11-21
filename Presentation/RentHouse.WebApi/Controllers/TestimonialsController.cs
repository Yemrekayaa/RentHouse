using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Testimonials.Commands.Create;
using RentHouse.Application.Features.CQRS.Testimonials.Commands.Remove;
using RentHouse.Application.Features.CQRS.Testimonials.Commands.Update;
using RentHouse.Application.Features.CQRS.Testimonials.Queries.GetById;
using RentHouse.Application.Features.CQRS.Testimonials.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdTestimonialQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestimonialCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTestimonialCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveTestimonialCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
