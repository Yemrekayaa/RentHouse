using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Pricings.Commands.Create;
using RentHouse.Application.Features.CQRS.Pricings.Commands.Remove;
using RentHouse.Application.Features.CQRS.Pricings.Commands.Update;
using RentHouse.Application.Features.CQRS.Pricings.Queries.GetById;
using RentHouse.Application.Features.CQRS.Pricings.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdPricingQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePricingCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePricingCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemovePricingCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
