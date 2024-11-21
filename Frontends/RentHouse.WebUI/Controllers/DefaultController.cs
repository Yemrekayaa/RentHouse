using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
