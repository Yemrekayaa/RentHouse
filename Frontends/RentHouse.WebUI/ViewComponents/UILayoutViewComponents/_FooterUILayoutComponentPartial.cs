using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.FooterAddressDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly ApiService _apiService;

        public _FooterUILayoutComponentPartial(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _apiService.GetAsync<ResultAddressDto>("FooterAddresses/1");
            return View(value);
        }
    }
}
