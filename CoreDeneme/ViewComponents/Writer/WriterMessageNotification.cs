﻿
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDeneme.ViewComponents.Writer
{
    public class WriterMessageNotification :ViewComponent
    {
        Message2Manager nm = new Message2Manager(new EfMessage2Repository());
        Context c= new Context();
        public IViewComponentResult Invoke( )
            
        {
            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();


            var values = nm.GetInboxListByWriter(writerID);
          
            return View(values);
        }
    }
}
