using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(x => x.Categories)
                .WithMany(s => s.Products);
        }
    }
}
