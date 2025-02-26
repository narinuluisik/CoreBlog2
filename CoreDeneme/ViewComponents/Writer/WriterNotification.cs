using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDeneme.ViewComponents.Writer
{
    public class WriterNotification :ViewComponent
    {
 
            NotificitionManager nm = new NotificitionManager(new EfNotificitionRepository());
            public IViewComponentResult Invoke()
            {
            var values = nm.GetList();
                return View(values);
            }
        }
    }

