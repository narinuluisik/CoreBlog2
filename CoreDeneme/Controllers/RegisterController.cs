using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDeneme.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm=new WriterManager(new EfWriterRepository());
		
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer p)
		{
			WriterValidator	 wr = new WriterValidator();
			ValidationResult results=wr.Validate(p);
			if(results.IsValid) 
			
			{
				p.WriterStatus = true;
				p.WriterAbout = "deneme test";
				wm.WriterAdd(p);
				return RedirectToAction("Index", "Blog");

			}
			else
			{
				foreach(var x in results.Errors)
				{
					ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
				}
			}
			return View();	

		}
	}
}
