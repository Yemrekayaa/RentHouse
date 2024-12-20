﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentHouse.Dto;
using RentHouse.Dto.FeatureDtos;
using RentHouse.Dto.HouseDtos;
using RentHouse.Dto.HouseImagesDtos;
using RentHouse.Dto.LocationDto;
using RentHouse.Dto.ReservationDto;
using RentHouse.WebUI.Services;

namespace RentHouse.WebUI.Areas.Admin.Controllers
{
    public class HouseController : AdminBaseController
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


            var response = await _apiService.GetAsync<PaginationDto<ResultHouseWithFeaturesDto>>(
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
            var createHouseWithFeatureDto = new CreateHouseWithFeatureDto();
            createHouseWithFeatureDto.HouseFeatures = new List<CreateHouseWithFeatureListDto>();
            foreach (var item in featureValues)
            {
                createHouseWithFeatureDto.HouseFeatures.Add(new CreateHouseWithFeatureListDto
                {
                    Available = false,
                    FeatureId = item.FeatureID
                });
            }
            return View(createHouseWithFeatureDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHouseWithFeatureDto createHouseWithFeatureDto)
        {
            var uploadedFiles = Request.Form.Files;
            var imageUrls = new List<CreateHouseImagesDto>();

            if (uploadedFiles.Count > 0)
            {
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/uploads");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                foreach (var file in uploadedFiles)
                {
                    if (file.Length > 0 && file.ContentType.StartsWith("image/"))
                    {

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string filePath = Path.Combine(uploadFolder, fileName);


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }


                        imageUrls.Add(new CreateHouseImagesDto
                        {
                            ImageUrl = "/images/uploads/" + fileName,
                        });
                    }
                }
            }

            createHouseWithFeatureDto.HouseImages = imageUrls;
            createHouseWithFeatureDto.CoverImageUrl = imageUrls[0].ImageUrl;

            var response = await _apiService.RequestAsync(HttpMethod.Post, "Houses/with-features", createHouseWithFeatureDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "House", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _apiService.RequestAsync<object>(HttpMethod.Delete, $"Houses/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "House", new { area = "Admin" });
            }
            return RedirectToAction("Index", "House", new { area = "Admin" });
        }
        [HttpGet]
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

            var featureValues = await _apiService.GetAsync<IEnumerable<ResultFeatureDto>>("Features");
            ViewBag.FeatureValues = featureValues;

            var houseValues = await _apiService.GetAsync<UpdateHouseWithFeatureDto>($"Houses/{id}/with-features");

            return View(houseValues);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateHouseWithFeatureDto updateHouseWithFeatureDto)
        {
            var uploadedFiles = Request.Form.Files;
            var imageUrls = new List<UpdateHouseImagesDto>();

            if (updateHouseWithFeatureDto.ExistingImages != null)
            {
                foreach (var existingImage in updateHouseWithFeatureDto.ExistingImages)
                {
                    imageUrls.Add(new UpdateHouseImagesDto
                    {
                        ImageUrl = existingImage
                    });
                }
            }


            if (uploadedFiles.Count > 0)
            {
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/uploads");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                foreach (var file in uploadedFiles)
                {
                    if (file.Length > 0 && file.ContentType.StartsWith("image/"))
                    {

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string filePath = Path.Combine(uploadFolder, fileName);


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }


                        imageUrls.Add(new UpdateHouseImagesDto
                        {

                            ImageUrl = "/images/uploads/" + fileName,
                        });
                    }
                }
            }

            updateHouseWithFeatureDto.HouseImages = imageUrls;
            updateHouseWithFeatureDto.CoverImageUrl = imageUrls[int.Parse(updateHouseWithFeatureDto.CoverImageUrl)].ImageUrl;


            var response = await _apiService.RequestAsync(HttpMethod.Put, "Houses/with-features", updateHouseWithFeatureDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "House", new { area = "Admin" });
            }
            return RedirectToAction("Index", "House", new { area = "Admin" });
        }

        [HttpGet("[Area]/[Controller]/{id}/Reservation")]
        public async Task<IActionResult> Reservation([FromRoute] int id, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var houseResponse = await _apiService.GetAsync<ResultHouseWithFeaturesDto>($"Houses/{id}/with-location");
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
