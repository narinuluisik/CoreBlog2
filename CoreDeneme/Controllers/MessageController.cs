using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDeneme.Controllers
{
    public class MessageController : Controller
    {
        private readonly Message2Manager _nm;
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;

        // 🔹 Bağımlılıkları Controller'a Enjekte Ediyoruz
        public MessageController(UserManager<AppUser> userManager)
        {
            _nm = new Message2Manager(new EfMessage2Repository());
            _context = new Context();
            _userManager = userManager;
        }

        public async Task<IActionResult> InBox()
        {
            // 🔹 Şu an giriş yapan kullanıcıyı buluyoruz
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return Content("Hata: Kullanıcı bulunamadı!");
            }

            // 🔹 Kullanıcının e-posta adresini kullanarak WriterID'yi çekiyoruz
            var writerID = _context.Writers
                .Where(x => x.WriterMail == user.Email)
                .Select(y => y.WriterID)
                .FirstOrDefault();

            // 🔹 WriterID'ye göre gelen mesajları alıyoruz
            var values = _nm.GetInboxListByWriter(writerID);

            return View(values);
        }


                   public async Task<IActionResult> SendBox()
        {
            // 🔹 Şu an giriş yapan kullanıcıyı buluyoruz
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return Content("Hata: Kullanıcı bulunamadı!");
            }

            // 🔹 Kullanıcının e-posta adresini kullanarak WriterID'yi çekiyoruz
            var writerID = _context.Writers
                .Where(x => x.WriterMail == user.Email)
                .Select(y => y.WriterID)
                .FirstOrDefault();

            // 🔹 WriterID'ye göre gelen mesajları alıyoruz
            var values = _nm.GetSendBoxListByWriter(writerID);

            return View(values);
        }
        

          [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = _nm.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        // 🔹 [POST] Mesaj Gönderme İşlemi
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message2 p, string receiverEmail)
        {
            // 🔹 Giriş yapan kullanıcıyı alıyoruz
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return Content("Hata: Kullanıcı bulunamadı!");
            }

            // 🔹 Alıcıyı buluyoruz
            var receiver = _context.Writers.FirstOrDefault(x => x.WriterMail == receiverEmail);
            if (receiver == null)
            {
                ModelState.AddModelError("", "Hata: Alıcı bulunamadı!");
                return View(p);
            }

            // 🔹 Mesaj nesnesini oluşturuyoruz
            p.SenderID = _context.Writers.Where(x => x.WriterMail == user.Email).Select(y => y.WriterID).FirstOrDefault();
            p.ReceiverID = receiver.WriterID;
            p.MessageDate = DateTime.Now;
            p.MessageStatus = true;

            // 🔹 Mesajı kaydediyoruz
            _nm.TAdd(p);

            return RedirectToAction("InBox");
        }
    }
}