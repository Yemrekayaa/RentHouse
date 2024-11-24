using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.ReservationDto;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly ApiService _apiService;

        public ReservationController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetAsync<List<ResultReservationDto>>("Reservations");
            return View(values);
        }

        public async Task<IActionResult> Create()
        {
            var createReservationDto = new CreateReservationDto();
            createReservationDto.StartDate = DateTime.Now;
            createReservationDto.EndDate = DateTime.Now.AddDays(1);
            return View(createReservationDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationDto createReservationDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Post, "Reservations", createReservationDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
