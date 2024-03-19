using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
	public class PagesController : Controller
	{
		public IActionResult AccesDenied()
		{
			return View();
		}
	}
}
