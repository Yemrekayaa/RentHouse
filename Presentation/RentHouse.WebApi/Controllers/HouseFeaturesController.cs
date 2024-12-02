using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.HouseFeatures.Commands;

namespace RentHouse.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiExplorerSettings(GroupName = "RentHouse")]
	[ApiController]
	public class HouseFeaturesController : BaseController
	{

		[HttpPatch]
		public async Task<IActionResult> ChangeAvailable(UpdateHouseFeatureAvailableCommand updateHouseFeatureAvailableCommand)
		{
			await Mediator.Send(updateHouseFeatureAvailableCommand);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> CreateByHouse(CreateHouseFeatureByHouseCommand createHouseFeatureByHouseCommand)
		{
			await Mediator.Send(createHouseFeatureByHouseCommand);
			return Ok();
		}

	}
}
