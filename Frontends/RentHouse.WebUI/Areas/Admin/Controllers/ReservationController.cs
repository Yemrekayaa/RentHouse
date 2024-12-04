using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto;
using RentHouse.Dto.HouseDtos;
using RentHouse.Dto.ReservationDto;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    public class ReservationController : AdminBaseController
    {
        private readonly ApiService _apiService;

        public ReservationController(ApiService apiService)
        {
            _apiService = apiService;
        }


        public async Task<IActionResult> Index([FromQuery] int pageNumber = 1, int pageSize = 20)
        {
            var queryParams = new List<string>
            {
            $"PageNumber={pageNumber}",
            $"PageSize={pageSize}"
            };

            var response = await _apiService.GetAsync<PaginationDto<ResultReservationWithHouseDto>>(
                $"Reservations/with-house?{string.Join("&", queryParams)}");

            return View(response);
        }



        public async Task<IActionResult> Update(int id)
        {
            var reservationResponse = await _apiService.GetAsync<UpdateReservationDto>($"Reservations/{id}");

            var houseResponse = await _apiService.GetAsync<ResultHouseWithFeaturesDto>($"Houses/{reservationResponse.HouseID}/with-location");
            ViewBag.House = houseResponse;

            var reservationsResponse = await _apiService.GetAsync<PaginationDto<ResultReservationDto>>($"Houses/{reservationResponse.HouseID}/Reservations?PageSize={int.MaxValue}");
            ViewBag.Reservations = reservationsResponse.Items;

            return View(reservationResponse);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateReservationDto updateReservationDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Put, "Reservations", updateReservationDto);
            if (response.IsSuccessStatusCode)
            {
                TempData["ToastTitle"] = "Başarılı";
                TempData["ToastMessage"] = "İşlem başarıyla tamamlandı!";
                TempData["ToastClass"] = "toast-success";
                TempData["ShowToast"] = true; // Toast'ı tetikle
                return RedirectToAction("Reservation", "House", new { area = "Admin", id = updateReservationDto.HouseID });
            }

            TempData["ToastTitle"] = "Hata";
            TempData["ToastMessage"] = "Bir sorun oluştu!";
            TempData["ToastClass"] = "toast-error";
            TempData["ShowToast"] = true; // Hata için de tetiklenebilir
            return RedirectToAction("Reservation", "House", new { area = "Admin", id = updateReservationDto.HouseID });
        }


        public async Task<IActionResult> Create(int houseId)
        {
            var houseResponse = await _apiService.GetAsync<ResultHouseWithFeaturesDto>($"Houses/{houseId}/with-location");
            ViewBag.House = houseResponse;

            var reservationsResponse = await _apiService.GetAsync<PaginationDto<ResultReservationDto>>($"Houses/{houseId}/Reservations?PageSize={int.MaxValue}");
            ViewBag.Reservations = reservationsResponse.Items;

            var createReservationDto = new CreateReservationDto();
            createReservationDto.HouseID = houseResponse.houseID;
            return View(createReservationDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationDto createReservationDto, int houseId)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Post, "Reservations", createReservationDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Reservation", "House", new { area = "Admin", id = houseId });
            }
            return View();
        }


        public async Task<IActionResult> Remove(int id, int houseId)
        {
            var response = await _apiService.RequestAsync<object>(HttpMethod.Delete, $"Reservations/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Reservation", "House", new { area = "Admin", id = houseId });
            }
            return RedirectToAction("Index");
        }

    }
}
