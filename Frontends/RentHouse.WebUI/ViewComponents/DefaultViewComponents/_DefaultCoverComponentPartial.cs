using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.DefaultDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverComponentPartial : ViewComponent
    {
        private readonly ApiService _apiService;

        public _DefaultCoverComponentPartial(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _apiService.GetAsync<ResultBannerDto>("Banners/1");
            return View(values);
        }
    }
}
