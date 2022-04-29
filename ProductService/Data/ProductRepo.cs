using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Interface
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public void RemoveProduct(int id)
        {
            var product = GetById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var prod = GetById(id);
            prod.Name = product.Name;
            _context.SaveChanges();
            return prod;
        }
    }
}
