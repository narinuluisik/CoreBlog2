using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDeneme.ViewComponents.Writer
{
    public class WriterMessageNotification :ViewComponent
    {
        Message2Manager nm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke( )
            
        {

            int id = 4;
          
            var values = nm.GetInboxListByWriter(id);
          
            return View(values);
        }
    }
}
