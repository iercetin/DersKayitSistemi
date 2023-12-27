namespace DersKayitSistemi.Models
{
    public class Ders
    {
        [Key]
        public int Id { get; set; }
        public string DersKodu { get; set; }
        public string DersAdi { get; set; }
        public int DersKontenjan { get; set; }
        public int DersKredi{ get; set; }
    }
}
