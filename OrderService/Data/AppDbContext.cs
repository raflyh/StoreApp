using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<InVoice> InVoices { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Product>()
            .HasMany(p => p.Products)
            .WithOne(p => p.InVoices)
            .HasForeignKey(p => p.PlatformId);

            modelBuilder.Entity<Command>()
            .HasOne(c => c.Platform)
            .WithMany(c => c.Commands)
            .HasForeignKey(c => c.PlatformId);*/
        }
    }
}
