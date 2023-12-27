using System.ComponentModel.DataAnnotations.Schema;

namespace DersKayitSistemi.Models
{
    public class DersSecim
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        [ForeignKey("Ders")]
        public int DersId { get; set; }
        public virtual Ders Ders { get; set; }

        public bool OnayliMi { get; set; }
    }
}
