using COREKİTAP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COREKİTAP.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Kitap> kitaps { get; set; }
        public DbSet<OkumaGecmisi> okumaGecmisis { get; set; }
        public DbSet<Tür> türs { get; set; }
        public DbSet<Öneri> öneris { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Kitap>().HasKey(k => k.KitapID);
            builder.Entity<Kitap>().HasOne(k => k.Tür).WithMany(t => t.Kitaplar).HasForeignKey(k => k.TürID);

            builder.Entity<OkumaGecmisi>().HasKey(o => o.OkumaGecmisiID);
            builder.Entity<OkumaGecmisi>().HasOne(o => o.Kullanıcı).WithMany(k => k.OkumaGecmisi).HasForeignKey(o => o.KullanıcıID);
            builder.Entity<OkumaGecmisi>().HasOne(o => o.Kitap).WithMany(k => k.OkumaGecmisi).HasForeignKey(o => o.KitapID);

            builder.Entity<Öneri>().HasKey(o => o.ÖneriID);
            builder.Entity<Öneri>().HasOne(o => o.Kullanıcı).WithMany(k => k.Öneri).HasForeignKey(o => o.KullanıcıID);
            builder.Entity<Öneri>().HasOne(o => o.Kitap).WithMany(k => k.Öneri).HasForeignKey(o => o.KitapID);

            builder.Entity<Tür>().HasKey(t => t.TürID);
        }


    }
}
