using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentHouse.Dto.HouseDtos;

namespace RentHouse.WebUI.Controllers
{
    public class HouseController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public HouseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.name = "Evler";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Houses/with-location");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultHouseWithLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
