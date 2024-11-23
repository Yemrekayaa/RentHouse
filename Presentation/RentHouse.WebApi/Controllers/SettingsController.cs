using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Settings.CQRS.Settings.Commands.Create;
using RentHouse.Application.Settings.CQRS.Settings.Commands.Remove;
using RentHouse.Application.Settings.CQRS.Settings.Commands.Update;
using RentHouse.Application.Settings.CQRS.Settings.Queries.GetById;
using RentHouse.Application.Settings.CQRS.Settings.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class SettingsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListSettingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdSettingQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSettingCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSettingCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Mediator.Send(new RemoveSettingCommand(id));
            return Ok();
        }
    }
}
