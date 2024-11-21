using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Categories.Commands.Create;
using RentHouse.Application.Features.CQRS.Categories.Commands.Remove;
using RentHouse.Application.Features.CQRS.Categories.Commands.Update;
using RentHouse.Application.Features.CQRS.Categories.Queries.GetById;
using RentHouse.Application.Features.CQRS.Categories.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListCategoryQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdCategoryQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveCategoryCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
