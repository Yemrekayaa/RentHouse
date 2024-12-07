using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentHouse.Dto.ServiceDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.SharedViewComponents
{
    public class _OurServicesComponentPartial : ViewComponent
    {
        private readonly ApiService _apiService;

        public _OurServicesComponentPartial(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _apiService.GetAsync<List<ResultServiceDto>>("Services");
            return View(responseMessage);
        }
    }
}
