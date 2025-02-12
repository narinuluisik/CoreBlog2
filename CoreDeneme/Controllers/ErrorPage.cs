using Microsoft.AspNetCore.Mvc;

namespace CoreDeneme.Controllers
{
	public class ErrorPage : Controller
	{
		public IActionResult Error1(int code)
		{
			return View();
		}
	}
}
