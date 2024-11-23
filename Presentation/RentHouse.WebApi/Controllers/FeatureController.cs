using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Features.Commands.Create;
using RentHouse.Application.Features.CQRS.Features.Commands.Remove;
using RentHouse.Application.Features.CQRS.Features.Commands.Update;
using RentHouse.Application.Features.CQRS.Features.Queries.GetById;
using RentHouse.Application.Features.CQRS.Features.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class FeaturesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdFeatureQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFeatureCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFeatureCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Mediator.Send(new RemoveFeatureCommand(id));
            return Ok();
        }
    }
}
