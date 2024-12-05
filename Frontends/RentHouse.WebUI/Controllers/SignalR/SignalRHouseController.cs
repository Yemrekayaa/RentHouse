using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Controllers.SignalR
{
    public class SignalRHouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
