using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
