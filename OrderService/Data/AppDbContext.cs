using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<InVoice>()
                .HasOne(i => i.InVoice)
                .WithMany(p => p.Products);
             */
            //modelBuilder.Entity<Category>()
            //    .HasMany(x => x.Products)
            //    .WithOne(s => s.Category);
        }
    }
}
