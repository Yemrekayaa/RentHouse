using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.AboutDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly ApiService _apiService;

        public AboutController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _apiService.GetAsync<UpdateAboutDto>("Abouts/1");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Put, "Abouts", updateAboutDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
