using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Banners.Commands.Create;
using RentHouse.Application.Features.CQRS.Banners.Commands.Remove;
using RentHouse.Application.Features.CQRS.Banners.Commands.Update;
using RentHouse.Application.Features.CQRS.Banners.Queries.GetById;
using RentHouse.Application.Features.CQRS.Banners.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListBannerQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdBannerQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBannerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBannerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveBannerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
