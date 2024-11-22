using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.AboutDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.SharedViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly ApiService _apiService;

        public _AboutUsComponentPartial(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _apiService.GetAsync<ResultAboutDto>("Abouts/1");
            return View(value);
        }
    }
}
