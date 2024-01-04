using DersKayitSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
                ViewBag.KullaniciNo = kullaniciNo;
            }
            else
            {
                return RedirectToAction("Login", "Kullanici");
            }

            return View(dersler);
        }

        public IActionResult DersOnayla()
        {
            var dersSecimleri = _context.DersSecim.Include(ds => ds.Kullanici).Include(ds => ds.Ders).ToList();

            foreach (var item in dersSecimleri)
            {
                _logger.LogInformation($"DersSecim Id: {item.Id}, Kullanici: {item.Kullanici}, Ders: {item.Ders}");
            }

            return View(dersSecimleri);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}