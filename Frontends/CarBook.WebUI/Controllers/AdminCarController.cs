using CarBook.Dto.BlogDtos;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Experimental;
using Newtonsoft.Json;
using System.Security.Permissions;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    [Route("Admin/Car/")]
    [Authorize(Roles = "Member")]
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7161/api/Cars/GetCarsWithBrands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7161/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                List<SelectListItem> brandValues = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandId.ToString()
                                                    }).ToList();
                ViewBag.brandValues = brandValues;
                return View();
            }
            return View();
        }
        [HttpPost]
        [Route("CreateCar")]
        public async Task<IActionResult>CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7161/api/Cars",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("RemoveCar/{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7161/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7161/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                List<SelectListItem> brandValues = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandId.ToString()
                                                    }).ToList();
                ViewBag.brandValues = brandValues;
            }

            var responseMessage1 = await client.GetAsync($"https://localhost:7161/api/Cars/{id}");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData1);
                return View(values1);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult>UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7161/api/Cars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
    }
}
