using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.FeatureDtos;

namespace RentHouse.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CreateFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new CreateFeatureDto());
        }

    }
}
