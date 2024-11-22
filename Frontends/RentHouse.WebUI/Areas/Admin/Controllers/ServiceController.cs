using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.ServiceDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly ApiService _apiService;

        public ServiceController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetAsync<List<ResultServiceDto>>("Services");
            return View(values);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _apiService.RequestAsync<object>(HttpMethod.Delete, $"Services/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Put, "Services", updateServiceDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult UpdateServicePartial()
        {
            return PartialView();
        }

    }
}
