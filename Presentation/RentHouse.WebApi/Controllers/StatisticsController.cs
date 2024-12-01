using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.Statistics.Queries.GetList;

namespace RentHouse.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "RentHouse")]
	[ApiController]
	public class StatisticsController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var values = await Mediator.Send(new GetListStatisticQuery());
			return Ok(values);
		}

	}
}
