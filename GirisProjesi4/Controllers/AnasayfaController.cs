using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GirisProjesi4.Models.Ambar;
using GirisProjesi4.Models;
using GirisProjesi4.Models.Soyut;
namespace GirisProjesi4.Controllers
{
    public class AnasayfaController : Controller
    {
        public IAmbar ambar = OrnekVeriAmbari.Veri; //IAmbar interface'siyle Controller ve OrnekVeriAmbarı arasında izolasyon sağladık.
        
        public IActionResult Index()
        {
            return View(ambar.Urunler);
            //return View(OrnekVeriAmbari.Veri.Urunler.Where(urun => urun?.Fiyat < 30));
        }
        [HttpGet]
        public IActionResult UrunEkle()
        {
            return View(new Urun());
        }
        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            ambar.UrunEkle(urun);
            return RedirectToAction("Index");
        }
    }
}