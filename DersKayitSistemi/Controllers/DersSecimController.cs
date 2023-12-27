﻿using Microsoft.AspNetCore.Mvc;
using DersKayitSistemi.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DersKayitSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersSecimController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DersSecimController> _logger;

        public DersSecimController(ApplicationDbContext context, ILogger<DersSecimController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("select")]
        public IActionResult SelectDers([FromBody] DersSecimDto dersSecimDto)
        {
            _logger.LogInformation($"Ders seçimi isteği: KullaniciId: {dersSecimDto.KullaniciNo}, CourseCode: {dersSecimDto.DersKodu}");

            var ders = _context.Dersler.FirstOrDefault(d => d.DersKodu == dersSecimDto.DersKodu);
            if (ders == null)
            {
                return NotFound("Ders bulunamadı.");
            }

            var kull = _context.Kullanicilar.FirstOrDefault(k => k.KullaniciNo == dersSecimDto.KullaniciNo);
            if (kull == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            var dersSecim = new DersSecim
            {
                KullaniciId = kull.KullaniciId,
                DersId = ders.Id,
                OnayliMi = false
            };

            _context.DersSecim.Add(dersSecim);
            _context.SaveChanges();

            return Ok();
        }


        [HttpGet("student/{kullaniciId}")]
        public IActionResult GetDersSecimlerByStudent(int kullaniciId)
        {
            var dersSecimler = _context.DersSecim
                .Where(ds => ds.KullaniciId == kullaniciId)
                .ToList();

            return Ok(dersSecimler);
        }
    }
}

public class DersSecimDto
{
    public string KullaniciNo { get; set; }
    public string DersKodu { get; set; }
}