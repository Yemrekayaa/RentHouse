using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Controllers
{
	public class AboutController : Controller
	{
		[Route("hakkimizda")]
		public IActionResult Index()
		{
			ViewBag.name = "Hakkımızda";
			return View();
		}
	}
}
