using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentHouse.Dto.HouseDtos;
using RentHouse.Dto.LocationDto;
using RentHouse.Dto.ReservationDto;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var values = await _apiService.GetAsync<List<ResultLocationDto>>("Locations");
            List<SelectListItem> locationValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.LocationID.ToString()
                                                   }).ToList();
            ViewBag.LocationValues = locationValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHouseDto createHouseDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Post, "Houses", createHouseDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _apiService.RequestAsync<object>(HttpMethod.Delete, $"Houses/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var locationResponse = await _apiService.GetAsync<List<ResultLocationDto>>("Locations");
            List<SelectListItem> locationValues = (from x in locationResponse
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.LocationID.ToString()
                                                   }).ToList();
            ViewBag.LocationValues = locationValues;


            var houseValues = await _apiService.GetAsync<UpdateHouseDto>($"Houses/{id}");

            return View(houseValues);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateHouseDto updateHouseDto)
        {

            var response = await _apiService.RequestAsync(HttpMethod.Put, "Houses", updateHouseDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet("[Area]/[Controller]/{id}/Reservation")]
        public async Task<IActionResult> Reservation(int id)
        {
            var houseResponse = await _apiService.GetAsync<ResultHouseWithLocationDto>($"Houses/{id}/with-location");
            ViewBag.House = houseResponse;

            var response = await _apiService.GetAsync<List<ResultReservationDto>>($"Houses/{id}/Reservations");
            return View(response);
        }

        [HttpGet("[Area]/[Controller]/{id}/Reservation/Create")]
        public async Task<IActionResult> ReservationCreate(int id)
        {
            var houseResponse = await _apiService.GetAsync<ResultHouseWithLocationDto>($"Houses/{id}/with-location");
            ViewBag.House = houseResponse;

            var reservationsResponse = await _apiService.GetAsync<List<ResultReservationDto>>($"Houses/{id}/Reservations");
            ViewBag.Reservations = reservationsResponse;

            var createReservationDto = new CreateReservationDto();
            createReservationDto.HouseID = houseResponse.houseID;
            return View(createReservationDto);
        }

        [HttpPost("[Area]/[Controller]/ReservationCreate")]
        public async Task<IActionResult> ReservationCreate(CreateReservationDto createReservationDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Post, "Reservations", createReservationDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
