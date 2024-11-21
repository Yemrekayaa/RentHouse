using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.ViewComponents.SharedViewComponents
{
	public class _StatisticsComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
