using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Controllers
{
    public class TermConditionsController : Controller
    {
        [Route("Hukum-ve-kosullar")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
