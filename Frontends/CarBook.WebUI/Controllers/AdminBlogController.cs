using CarBook.Dto.AuthorDtos;
using CarBook.Dto.BlogDtos;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    [Route("Admin/Blog/")]
	[Authorize(Roles = "Member")]
	public class AdminBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7161/api/Blogs/GetBlogsWithAuthorAndCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogWithAuthorAndCategory>>(jsonData);
                return View(values);
            }
            return View();
        }
       
        [Route("RemoveBlog/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7161/api/Blogs?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }

}
