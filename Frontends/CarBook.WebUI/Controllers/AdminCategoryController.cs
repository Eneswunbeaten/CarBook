using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    using CarBook.Dto.CategoryDtos;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Text;


    namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
    {
        [Route("Admin/AdminCategory")]
		[Authorize(Roles = "Member")]
		public class AdminCategoryController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;
            public AdminCategoryController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }
            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7161/api/Categories");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                    return View(values);
                }
                return View();
            }

            [HttpGet]
            [Route("CreateCategory")]
            public IActionResult CreateCategory()
            {
                return View();
            }

            [HttpPost]
            [Route("CreateCategory")]
            public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createCategoryDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7161/api/Categories", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            [Route("RemoveCategory/{id}")]
            public async Task<IActionResult> RemoveCategory(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync("https://localhost:7161/api/Categories?id=" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            [HttpGet]
            [Route("UpdateCategory/{id}")]
            public async Task<IActionResult> UpdateCategory(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var resposenMessage = await client.GetAsync($"https://localhost:7161/api/Categories/{id}");
                if (resposenMessage.IsSuccessStatusCode)
                {
                    var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                    return View(values);
                }
                return View();
            }

            [HttpPost]
            [Route("UpdateCategory/{id}")]
            public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7161/api/Categories/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    }

}
