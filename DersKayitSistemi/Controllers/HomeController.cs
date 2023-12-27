﻿using DersKayitSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DersKayitSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Ders> GetDersler()
        {
            return _context.Dersler.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult DersSec()
        {
            var dersler = GetDersler();

            // Session'dan KullaniciNo'yu al
            var kullaniciNo = HttpContext.Session.GetString("KullaniciNo");
            if (kullaniciNo != null)
            {
                ViewBag.KullaniciNo = kullaniciNo; // ViewBag kullanarak view'a veriyi aktar
            }
            else
            {
                // KullaniciNo session'da yoksa, uygun bir işlem yapın
                // Örneğin, kullanıcıyı giriş sayfasına yönlendirme
                return RedirectToAction("Login", "Kullanici");
            }

            return View(dersler);
        }

        public IActionResult DersOnayla()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}