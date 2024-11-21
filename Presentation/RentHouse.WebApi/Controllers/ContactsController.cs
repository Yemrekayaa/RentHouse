using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Contacts.Commands.Create;
using RentHouse.Application.Features.CQRS.Contacts.Commands.Remove;
using RentHouse.Application.Features.CQRS.Contacts.Commands.Update;
using RentHouse.Application.Features.CQRS.Contacts.Queries.GetById;
using RentHouse.Application.Features.CQRS.Contacts.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListContactQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdContactQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContactCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveContactCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
