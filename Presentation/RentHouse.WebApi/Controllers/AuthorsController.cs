using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Authors.Commands.Create;
using RentHouse.Application.Features.CQRS.Authors.Commands.Remove;
using RentHouse.Application.Features.CQRS.Authors.Commands.Update;
using RentHouse.Application.Features.CQRS.Authors.Queries.GetById;
using RentHouse.Application.Features.CQRS.Authors.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListAuthorQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdAuthorQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveAuthorCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
