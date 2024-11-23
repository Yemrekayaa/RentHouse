using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Abouts.Commands.Create;
using RentHouse.Application.Features.CQRS.Abouts.Commands.Remove;
using RentHouse.Application.Features.CQRS.Abouts.Commands.Update;
using RentHouse.Application.Features.CQRS.Abouts.Queries.GetById;
using RentHouse.Application.Features.CQRS.Abouts.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class AboutsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListAboutQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdAboutQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAboutCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAboutCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveAboutCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
