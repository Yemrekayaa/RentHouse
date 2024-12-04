using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.HouseImages.Commands.Create;
using RentHouse.Application.Features.CQRS.HouseImages.Commands.Remove;
using RentHouse.Application.Features.CQRS.HouseImages.Commands.Update;
using RentHouse.Application.Features.CQRS.HouseImages.Queries.GetById;
using RentHouse.Application.Features.CQRS.HouseImages.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class HouseImagesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListHouseImageQuery());
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdHouseImageQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHouseImageCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateHouseImageCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveHouseImageCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
