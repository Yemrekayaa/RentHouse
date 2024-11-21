using Microsoft.AspNetCore.Mvc;

namespace RentHouse.WebUI.ViewComponents.DefaultViewComponents
{
    public class _RemoveComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
