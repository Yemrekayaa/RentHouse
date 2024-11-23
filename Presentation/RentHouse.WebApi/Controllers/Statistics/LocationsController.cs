using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Locations.Queries.GetCount;

namespace RentHouse.WebApi.Controllers.Statistics
{
    [ApiController]
    [Area("Statistics")]
    [ApiExplorerSettings(GroupName = "Statistics")]
    [Route("api/[area]/[controller]")]

    public class LocationsController : BaseController
    {

        [HttpGet("Count")]
        public async Task<IActionResult> Count()
        {
            var value = await Mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }
    }
}
