﻿using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto;
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
        [HttpGet("evler")]
        public async Task<IActionResult> Index(
                [FromQuery] string startDate,
                [FromQuery] string endDate,
                int pageNumber = 1,
                int pageSize = 9,
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


            var response = await _apiService.GetAsync<PaginationDto<ResultHouseWithFeaturesDto>>(
                $"Houses/with-location?{string.Join("&", queryParams)}");

            return View(response);
        }



        [Route("ev/{name}-{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var calendarValues = await _apiService.GetAsync<PaginationDto<ResultReservationDto>>($"Houses/{id}/Reservations?PageSize={int.MaxValue}");

            ViewBag.CalendarValues = calendarValues.Items;


            var values = await _apiService.GetAsync<ResultHouseWithFeaturesDto>($"Houses/{id}/with-features");
            return View(values);
        }


    }
}
