using Microsoft.AspNetCore.Mvc;

namespace CoreDeneme.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
