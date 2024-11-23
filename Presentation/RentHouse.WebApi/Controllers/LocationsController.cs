using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Locations.Commands.Create;
using RentHouse.Application.Features.CQRS.Locations.Commands.Remove;
using RentHouse.Application.Features.CQRS.Locations.Commands.Update;
using RentHouse.Application.Features.CQRS.Locations.Queries.GetById;
using RentHouse.Application.Features.CQRS.Locations.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class LocationsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdLocationQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLocationCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLocationCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Mediator.Send(new RemoveLocationCommand(id));
            return Ok();
        }
    }
}
