namespace DersKayitSistemi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<DersSecim> DersSecim { get; set; }
    }

}
