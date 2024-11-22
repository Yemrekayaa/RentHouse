using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.LocationDto;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly ApiService _apiService;

        public LocationController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetAsync<List<ResultLocationDto>>("Locations");
            return View(values);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _apiService.RequestAsync<object>(HttpMethod.Delete, $"Locations/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationDto createLocationDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Post, "Locations", createLocationDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult CreateLocationPartial()
        {
            return PartialView();

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateLocationDto updateLocationDto)
        {

            var response = await _apiService.RequestAsync(HttpMethod.Put, "Locations", updateLocationDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult UpdateLocationPartial()
        {
            return PartialView();

        }

    }
}
