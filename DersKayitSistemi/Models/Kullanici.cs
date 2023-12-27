namespace DersKayitSistemi.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }

        public string KullaniciIsim { get; set; }

        public string KullaniciNo { get; set; }

        public string KullaniciSifre { get; set; }

        public KullaniciTipi KullaniciTipi { get; set; }
    }

    public enum KullaniciTipi
    {
        Ogrenci,
        Ogretmen
    }
}
