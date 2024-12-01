using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.HouseDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SearchHouseComponentPartial : ViewComponent
    {
        private readonly ApiService _apiService;

        public _SearchHouseComponentPartial(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var filter = new HouseFilterByDate();
            return View(filter);
        }
    }
}
