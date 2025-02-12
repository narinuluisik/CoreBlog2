using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDeneme.ViewComponents.Blog
{
	public class WriterLastBlog	  :ViewComponent
	{

		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListByWrite(1);
			return View(values);
		}
	}
}
