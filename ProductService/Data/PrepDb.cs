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

        private static void SeedData(AppDbContext? appDbContext, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Migrating --");
                try
                {
                    appDbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Migrate Failed {ex.Message} --");
                }
            }

            if (!appDbContext.Products.Any())
            {
                Console.WriteLine("--> Seeding Data --");
                var products = new List<Product>()
                {
                    new Product() { Name = "Gundam Model X", Price = 500.000, Categories = new List<Category>() 
                        { 
                            new Category() { Name = "Toys" }, 
                            new Category(){ Name = "Hobby" } 
                        }
                    },
                    new Product() { Name = "Pet Cargo", Price = 150.000, Categories = new List<Category>()
                        {
                            new Category() { Name = "Pets"},
                            new Category(){ Name = "Items"}
                        }
                    }
                };
                products.ForEach(p => appDbContext.Products.AddRange(p));
                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data Already Exist --");
            }
        }
    }
}
