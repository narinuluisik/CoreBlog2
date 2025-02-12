using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDeneme.Controllers
{
    public class BlogController : Controller
    {
		
        
            BlogManager bm = new BlogManager(new EfBlogRepository());

            public IActionResult Index()
            {
                var values = bm.GetBlogListWithCategory();
                return View(values);
            }
		public IActionResult BlogReadAll(int id)
		{
			var values = bm.GetBlogByID(id); // Tekil bir nesne döndürüyor
			ViewBag.i = id;
			return View(values); // Tek bir nesne olduğu için View düzenlenmeli!
		}


	}
}
