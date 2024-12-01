using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto;
using RentHouse.Dto.HouseDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.DefaultViewComponents
{
    public class _LastHousesComponentPartial : ViewComponent
    {
        private readonly ApiService _apiService;

        public _LastHousesComponentPartial(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
                [FromQuery] string startDate,
                [FromQuery] string endDate,
                int pageNumber = 1,
                int pageSize = 5,
                string orderBy = "Id",
                bool isDescending = true)

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
    }
}
