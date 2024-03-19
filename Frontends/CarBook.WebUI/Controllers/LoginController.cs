using CarBook.Dto.LoginDtos;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CarBook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CheckLoginDto checkLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content=new StringContent(JsonSerializer.Serialize(checkLoginDto),Encoding.UTF8,"application/json");
            var responseMessage= await client.PostAsync("https://localhost:7161/api/Login",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var tokenmodel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                if(tokenmodel is not null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token=handler.ReadJwtToken(tokenmodel.Token);
                    var claims = token.Claims.ToList();
                    if(tokenmodel.Token is not null)
                    {
                        claims.Add(new Claim("accessToken", tokenmodel.Token));
                        var claimsidentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenmodel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity), authProps);
                        return RedirectToAction("Index","AdminCar");
                    }
                }
            }

            return View();
        }
    }
}
