using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentHouse.Dto.TestimonialDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.ViewComponents.SharedViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly ApiService _apiService;

        public _TestimonialComponentPartial(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _apiService.GetAsync<List<ResultTestimonialDto>>("Testimonials");

            return View(responseMessage);
        }
    }
}
