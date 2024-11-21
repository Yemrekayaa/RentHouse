using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Blogs.Commands.Create;
using RentHouse.Application.Features.CQRS.Blogs.Commands.Remove;
using RentHouse.Application.Features.CQRS.Blogs.Commands.Update;
using RentHouse.Application.Features.CQRS.Blogs.Queries.GetById;
using RentHouse.Application.Features.CQRS.Blogs.Queries.GetList;
using RentHouse.Application.Features.CQRS.Blogs.Queries.GetListWithAuthor;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdBlogQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBlogCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveBlogCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("with-author")]
        public async Task<IActionResult> GetWithAuthor([FromQuery] int? count)
        {
            var values = await Mediator.Send(new GetBlogListWithAuthorQuery(count));
            return Ok(values);
        }
    }
}
