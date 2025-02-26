using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDeneme.Controllers
{
	

	public class BlogController : Controller
    {
    
        
            BlogManager bm = new BlogManager(new EfBlogRepository());

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        [AllowAnonymous]
        public IActionResult Index()
            {
                var values = bm.GetBlogListWithCategory();
                return View(values);
            }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
		{
			var values = bm.GetBlogByID(id); // Tekil bir nesne döndürüyor
			ViewBag.i = id;
			return View(values); // Tek bir nesne olduğu için View düzenlenmeli!
		}
		
		public IActionResult BlogListByWriter()
		{
            Context c = new Context();
            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();


          //  var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var values = bm.GetListWithCategoryByWriterBm(writerID);
			return View(values);
		}
		[HttpGet]
		public IActionResult BlogAdd()
		{
           

            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem>categoryvalues=(from x in cm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text=x.CategoryName,
                                                    Value=x.CategoryID.ToString()
                                                }).ToList();
            ViewBag.cv= categoryvalues;
			return View();
		}

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)

            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");

            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
                var value= bm.TGetById(id);
            bm.TDelete(value);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue= bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;


            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {

            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            p.WriterID=writerID;
            p.BlogCreateDate=DateTime.Now.ToShortDateString();
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }


    }
}
