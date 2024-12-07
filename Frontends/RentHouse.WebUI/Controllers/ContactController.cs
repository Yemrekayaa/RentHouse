using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentHouse.Dto.ContactDtos;
using RentHouse.WebUI.Services;
using System.Text;

namespace RentHouse.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApiService _apiService;

        public ContactController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("iletisim")]
        public IActionResult Index()
        {
            ViewBag.name = "İletişim";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {

            createContactDto.SendDate = DateTime.Now;

            var responseMessage = await _apiService.RequestAsync(HttpMethod.Post, "Contacts", createContactDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();

        }
    }
}
