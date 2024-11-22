using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.FeatureDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly ApiService _apiService;

        public FeatureController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetAsync<List<ResultFeatureDto>>("Features");
            return View(values);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _apiService.RequestAsync<object>(HttpMethod.Delete, $"Features/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Post, "Features", createFeatureDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult CreateFeaturePartial()
        {
            return PartialView();

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {

            var response = await _apiService.RequestAsync(HttpMethod.Put, "Features", updateFeatureDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult UpdateFeaturePartial()
        {
            return PartialView();

        }

    }
}
