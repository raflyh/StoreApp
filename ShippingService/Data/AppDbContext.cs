using Microsoft.EntityFrameworkCore;
using ShippingService.Models;

namespace ShippingService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<InVoice> inVoices { get; set; }
        public DbSet<Shipping> Shippings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
