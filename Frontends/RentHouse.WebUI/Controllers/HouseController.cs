using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.HouseDtos;
using RentHouse.Dto.ReservationDto;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Controllers
{
	public class HouseController : Controller
	{
		private readonly ApiService _apiService;

		public HouseController(ApiService apiService)
		{
			_apiService = apiService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _apiService.GetAsync<List<ResultHouseWithLocationDto>>("Houses/with-location");

			return View(values);
		}
		[Route("[Controller]/{id}")]
		public async Task<IActionResult> Details(int id)
		{
			var calendarValues = await _apiService.GetAsync<List<ResultReservationDto>>($"Houses/{id}/Reservations");
			ViewBag.CalendarValues = calendarValues;
			var values = await _apiService.GetAsync<ResultHouseWithLocationDto>($"Houses/{id}/with-location");
			return View(values);
		}


	}
}
