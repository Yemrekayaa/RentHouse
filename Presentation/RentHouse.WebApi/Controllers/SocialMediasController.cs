using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.SocialMedias.Commands.Create;
using RentHouse.Application.Features.CQRS.SocialMedias.Commands.Remove;
using RentHouse.Application.Features.CQRS.SocialMedias.Commands.Update;
using RentHouse.Application.Features.CQRS.SocialMedias.Queries.GetById;
using RentHouse.Application.Features.CQRS.SocialMedias.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await Mediator.Send(new GetListSocialMediaQuery());
            return Ok(values);
        }
        [AllowAnonymous]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdSocialMediaQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSocialMediaCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveSocialMediaCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
