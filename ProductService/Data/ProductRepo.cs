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
        public void Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _context.Products.Add(product);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.Include(s => s.Products).AsNoTracking().ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            var product = GetById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public bool Update(int id, Product product)
        {
            var prod = GetById(id);
            prod.Name = product.Name;
            _context.SaveChanges();
            return true;
        }
    }
}
