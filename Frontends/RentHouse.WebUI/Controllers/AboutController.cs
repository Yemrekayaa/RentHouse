using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Hakkımızda";
            return View();
        }
    }
}
