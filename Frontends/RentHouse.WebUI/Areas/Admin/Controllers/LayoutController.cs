using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();

        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
