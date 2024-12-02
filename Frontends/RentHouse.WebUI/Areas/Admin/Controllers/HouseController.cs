using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentHouse.Dto;
using RentHouse.Dto.FeatureDtos;
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

        public async Task<IActionResult> Index(
                [FromQuery] string startDate,
                [FromQuery] string endDate,
                int pageNumber = 1,
                int pageSize = 8,
                string orderBy = "",
                bool isDescending = false)
        {

            var queryParams = new List<string>
            {
            $"PageNumber={pageNumber}",
            $"PageSize={pageSize}"
            };


            if (!string.IsNullOrEmpty(startDate))
            {
                queryParams.Add($"StartDate={startDate}");
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                queryParams.Add($"EndDate={endDate}");
            }


            if (!string.IsNullOrEmpty(orderBy))
            {
                queryParams.Add($"OrderBy={orderBy}");
                queryParams.Add($"IsDescending={isDescending.ToString().ToLower()}");
            }


            var response = await _apiService.GetAsync<PaginationDto<ResultHouseWithLocationDto>>(
                $"Houses/with-location?{string.Join("&", queryParams)}");

            return View(response);
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
            var featureValues = await _apiService.GetAsync<IEnumerable<ResultFeatureDto>>("Features");
            ViewBag.FeatureValues = featureValues;
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
        public async Task<IActionResult> Reservation([FromRoute] int id, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var houseResponse = await _apiService.GetAsync<ResultHouseWithLocationDto>($"Houses/{id}/with-location");
            ViewBag.House = houseResponse;
            var queryParams = new List<string>
            {
            $"PageNumber={pageNumber}",
            $"PageSize={pageSize}"
            };

            var response = await _apiService.GetAsync<PaginationDto<ResultReservationDto>>(
                $"Houses/{id}/Reservations?{string.Join("&", queryParams)}");

            var calendarValues = await _apiService.GetAsync<PaginationDto<ResultReservationDto>>(
                $"Houses/{id}/Reservations?PageSize{int.MaxValue}");
            ViewBag.Calendar = calendarValues;
            return View(response);
        }







    }
}
