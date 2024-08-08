using Microsoft.EntityFrameworkCore;

namespace SecKaliteDb.Models
{
    public class SecKaliteDbDbContext : DbContext
    {
        public SecKaliteDbDbContext(DbContextOptions<SecKaliteDbDbContext> options) : base(options)
        {
            
        }

        public DbSet<BedenNumara> BedenNumara { get; set; }
        public DbSet<Birim> Birim { get; set; }
        public DbSet<KkdEnvanterTakip> KkdEnvanterTakip { get; set; }
        public DbSet<KkdGrubu> KkdGrubu { get; set; }
        public DbSet<KkdNiteligi> KkdNiteligi { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Unvan> Unvan { get; set; }
        public DbSet<Iade> Iade { get; set; }
        public DbSet<Teslimat> Teslimat { get; set; }
        public DbSet<PersonelBirim> PersonelBirim { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RegisterRequest> RegisterRequest { get; set; }
        public DbSet<SifreUnuttum> SifreUnuttum { get; set; }

    }
}
