using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Mvc;

namespace CoreDeneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = commentManager.GetCommentListWithBlog();
            return View();
        }
    }
}
