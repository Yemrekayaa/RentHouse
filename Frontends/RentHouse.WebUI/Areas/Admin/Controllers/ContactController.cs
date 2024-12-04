using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.ContactDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    public class ContactController : AdminBaseController
    {
        private readonly ApiService _apiService;

        public ContactController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _apiService.GetAsync<List<ResultContactDto>>("Contacts");
            return View(value);
        }


        public async Task<IActionResult> Remove(int id)
        {
            var response = await _apiService.RequestAsync<object>(HttpMethod.Delete, $"Contacts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
