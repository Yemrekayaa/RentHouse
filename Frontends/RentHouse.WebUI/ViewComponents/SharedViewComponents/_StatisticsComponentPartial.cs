using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.StatisticDto;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.SharedViewComponents
{
	public class _StatisticsComponentPartial : ViewComponent
	{
		private readonly ApiService _apiService;

		public _StatisticsComponentPartial(ApiService apiService)
		{
			_apiService = apiService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var value = await _apiService.GetAsync<ResultStatisticDto>("Statistics");
			return View(value);
		}
	}
}
