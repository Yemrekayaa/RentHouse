using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.HouseDtos;
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
            var values = await _apiService.GetAsync<List<ResultReservationWithHouseDto>>("Reservations/with-house");
            return View(values);
        }

        //public async Task<IActionResult> Create()
        //{
        //    var createReservationDto = new CreateReservationDto();
        //    createReservationDto.StartDate = DateTime.Now;
        //    createReservationDto.EndDate = DateTime.Now.AddDays(1);
        //    return View(createReservationDto);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(CreateReservationDto createReservationDto)
        //{
        //    var response = await _apiService.RequestAsync(HttpMethod.Post, "Reservations", createReservationDto);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}


        public async Task<IActionResult> Update(int id)
        {
            var reservationResponse = await _apiService.GetAsync<UpdateReservationDto>($"Reservations/{id}");

            var houseResponse = await _apiService.GetAsync<ResultHouseWithLocationDto>($"Houses/{reservationResponse.HouseID}/with-location");
            ViewBag.House = houseResponse;

            var reservationListResponse = await _apiService.GetAsync<List<ResultReservationDto>>($"Houses/{reservationResponse.HouseID}/Reservations");
            ViewBag.Reservations = reservationListResponse;

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
            var houseResponse = await _apiService.GetAsync<ResultHouseWithLocationDto>($"Houses/{houseId}/with-location");
            ViewBag.House = houseResponse;

            var reservationsResponse = await _apiService.GetAsync<List<ResultReservationDto>>($"Houses/{houseId}/Reservations");
            ViewBag.Reservations = reservationsResponse;

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
