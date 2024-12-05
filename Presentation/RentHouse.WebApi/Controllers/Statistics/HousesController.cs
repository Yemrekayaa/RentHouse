using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetCount;

namespace RentHouse.WebApi.Controllers.Statistics
{
    [ApiController]
    [Area("Statistics")]
    [ApiExplorerSettings(GroupName = "Statistics")]
    [Route("api/[area]/[controller]")]

    public class HousesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("Count")]
        public async Task<IActionResult> Count()
        {
            var value = await Mediator.Send(new GetHouseCountQuery());
            return Ok(value);
        }
    }
}
