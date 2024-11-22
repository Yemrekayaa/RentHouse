using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Houses.Commands.Create;
using RentHouse.Application.Features.CQRS.Houses.Commands.Remove;
using RentHouse.Application.Features.CQRS.Houses.Commands.Update;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetById;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetCount;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetList;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetWithLocation;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetWithPricing;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListHouseQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdHouseQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHouseCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateHouseCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Mediator.Send(new RemoveHouseCommand(id));
            return Ok();
        }
        [HttpGet("with-location")]
        public async Task<IActionResult> GetWithBrand([FromQuery] int? count)
        {
            var values = await Mediator.Send(new GetHouseWithLocationQuery(count));
            return Ok(values);
        }
        [HttpGet("with-price")]
        public async Task<IActionResult> GetWithPrice([FromQuery] int? count)
        {
            var values = await Mediator.Send(new GetHouseWithPricingQuery(count));
            return Ok(values);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> Count()
        {
            var value = await Mediator.Send(new GetHouseCountQuery());
            return Ok(value);
        }
    }
}
