using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using(var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext? context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Migrating --");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Migrate Failed {ex.Message} --");
                }
            }

            if (!context.Products.Any())
            {
                Console.WriteLine("--> Seeding Data --");
     
                context.Categories.AddRange(
                    new Category(){ Id = 1, Name = "Toys" },
                    new Category(){ Id = 2, Name = "Pets" },
                    new Category(){ Id = 3, Name = "Music" },
                    new Category(){ Id = 4, Name = "Foods" }
                    );
                context.SaveChanges();
                context.Products.AddRange(
                    new Product() { Id = 1, Name = "Gundam Model X", Price = 500000 , Quantity = 5, CategoryId = 1},
                    new Product() { Id = 2, Name = "Tamiya Model Z", Price = 250000 , Quantity = 2, CategoryId = 1},
                    new Product() { Id = 3, Name = "Pet Collar", Price = 50000, Quantity = 15, CategoryId = 2 },
                    new Product() { Id = 4, Name = "Cat Food 1Kg", Price = 250000, Quantity = 10, CategoryId = 2 },
                    new Product() { Id = 5, Name = "Guitar Strings", Price = 125000, Quantity = 2, CategoryId = 3 },
                    new Product() { Id = 6, Name = "Drum Stick", Price = 80000, Quantity = 6, CategoryId = 3 },
                    new Product() { Id = 7, Name = "Instant Ramen 20pcs", Price = 50000, Quantity = 20, CategoryId = 4 },
                    new Product() { Id = 8, Name = "Wagyu Beef 200g", Price = 250000, Quantity = 2, CategoryId = 4 }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data Already Exist --");
            }
        }
    }
}
