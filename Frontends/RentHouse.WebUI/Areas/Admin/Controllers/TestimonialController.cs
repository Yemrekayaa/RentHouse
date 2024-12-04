using Microsoft.AspNetCore.Mvc;
using RentHouse.Dto.TestimonialDtos;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    public class TestimonialController : AdminBaseController
    {
        private readonly ApiService _apiService;

        public TestimonialController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetAsync<List<ResultTestimonialDto>>("Testimonials");
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
        {
            var response = await _apiService.RequestAsync(HttpMethod.Post, "Testimonials", createTestimonialDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _apiService.RequestAsync<object>(HttpMethod.Delete, $"Testimonials/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return RedirectToAction("Index");


            var TestimonialValues = await _apiService.GetAsync<UpdateTestimonialDto>($"Testimonials/{id}");

            return View(TestimonialValues);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
        {

            var response = await _apiService.RequestAsync(HttpMethod.Put, "Testimonials", updateTestimonialDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
