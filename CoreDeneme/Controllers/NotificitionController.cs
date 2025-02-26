using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDeneme.Controllers
{
    public class NotificitionController : Controller
    {
        NotificitionManager nm= new NotificitionManager( new EfNotificitionRepository() );  
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AllNotificition() {

            var values=nm.GetList();
            return View(values); 
        }
    }
}
