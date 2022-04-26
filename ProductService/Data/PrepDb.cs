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
                var products = new List<Product>();
                var categories = new List<Category>()
                {
                    new Category() { Id = 1, Name = "Toys", Products = new List<Product>() 
                        { 
                            new Product() { Id = 1, Name = "Gundam Model X", Price = 500.000},
                            new Product() { Id = 2, Name = "Tamiya Model Z", Price = 250.000}
                        }
                    },
                    new Category() { Id = 2, Name = "Pets", Products = new List<Product>()
                        {
                            new Product() { Id = 3, Name = "Pet Collar", Price = 50.000},
                            new Product() { Id = 4, Name = "Cat Food 1Kg", Price = 250.000}
                        }
                    },
                    new Category() { Id = 3, Name = "Music", Products = new List<Product>()
                        {
                            new Product() { Id = 5, Name = "Guitar Strings", Price = 125.000},
                            new Product() { Id = 6, Name = "Drum Stick", Price = 80.000}
                        }
                    },
                    new Category() { Id = 4, Name = "Pets", Products = new List<Product>()
                        {
                            new Product() { Id = 7, Name = "Pet Collar", Price = 50.000},
                            new Product() { Id = 8, Name = "Cat Food 1Kg", Price = 250.000}
                        }
                    }
                };
                products.ForEach(p => context.Products.AddRange(p));
                categories.ForEach(p => context.Categories.AddRange(p));
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data Already Exist --");
            }
        }
    }
}
