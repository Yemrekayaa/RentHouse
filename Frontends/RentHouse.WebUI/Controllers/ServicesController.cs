using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Servislerimiz";
            return View();
        }
    }
}
