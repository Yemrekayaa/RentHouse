using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.FooterAddresses.Commands.Create;
using RentHouse.Application.Features.CQRS.FooterAddresses.Commands.Remove;
using RentHouse.Application.Features.CQRS.FooterAddresses.Commands.Update;
using RentHouse.Application.Features.CQRS.FooterAddresses.Queries.GetById;
using RentHouse.Application.Features.CQRS.FooterAddresses.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class FooterAddressesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdFooterAddressQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFooterAddressCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFooterAddressCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveFooterAddressCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
