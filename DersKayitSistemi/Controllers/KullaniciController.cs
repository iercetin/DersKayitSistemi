using Microsoft.AspNetCore.Mvc;
using DersKayitSistemi.Models; // Kullanici modelini içerir
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DersKayitSistemi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<KullaniciController> _logger;

        public KullaniciController(ApplicationDbContext context, ILogger<KullaniciController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GirisYap(string kullanici, string sifre)
        {
            var kull = _context.Kullanicilar
                .FirstOrDefault(k => k.KullaniciNo == kullanici && k.KullaniciSifre == sifre);

            if (kull != null)
            {
                HttpContext.Session.SetString("KullaniciNo", kull.KullaniciNo);

                if (kull.KullaniciTipi == KullaniciTipi.Ogrenci)
                {
                    return RedirectToAction("DersSec", "Home");
                }
                else if (kull.KullaniciTipi == KullaniciTipi.Ogretmen)
                {
                    return RedirectToAction("DersOnayla", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
