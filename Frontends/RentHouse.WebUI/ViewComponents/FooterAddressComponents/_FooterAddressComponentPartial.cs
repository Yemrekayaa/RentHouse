using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentHouse.Dto.FooterAddressDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial : ViewComponent
    {
        private readonly ApiService _apiService;

        public _FooterAddressComponentPartial(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var responseMessage = await _apiService.GetAsync<List<ResultAddressDto>>("FooterAddresses");

            return View(responseMessage);
        }
    }
}
