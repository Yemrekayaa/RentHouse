using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.FeatureDtos;

namespace RentHouse.WebUI.ViewComponents.DefaultViewComponents
{
    public class _UpdateFeatureComponentPartial : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new UpdateFeatureDto());
        }

    }
}

