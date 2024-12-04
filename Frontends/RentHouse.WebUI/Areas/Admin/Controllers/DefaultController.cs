using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{

    public class DefaultController : AdminBaseController
    {

        public IActionResult Index()
        {

            //return View();
            return RedirectToAction("Index", "House", new { area = "Admin" });
        }


    }
}
