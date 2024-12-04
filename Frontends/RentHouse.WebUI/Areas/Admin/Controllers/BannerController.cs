using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.BannerDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{

    public class BannerController : AdminBaseController
    {
        private readonly ApiService _apiService;

        public BannerController(ApiService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _apiService.GetAsync<UpdateBannerDto>("Banners/1");
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Put, "Banners", updateBannerDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
