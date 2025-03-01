﻿using CoreDeneme.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreDeneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterById(int writerid)
        {
            var findWriter=writers.FirstOrDefault(x=>x.Id == writerid);
            var jsonWriters=JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public  IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters=JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x=>x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        [HttpPost]
        public IActionResult UpdateWriter([FromBody] WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            if (writer == null)
                return NotFound("Güncellenecek yazar bulunamadı!");

            writer.Name = w.Name;

            return Json(writer);
        }


        public static List<WriterClass> writers = new List<WriterClass>

        {
            new WriterClass
            {
                Id=1,
                 Name ="Ayse"
            } ,
             new WriterClass
            {
                Id=2,
                 Name ="Ahmet"
            } ,      new WriterClass
            {
                Id=3,
                 Name ="Buse"
            } ,
        }; 
    }
}
