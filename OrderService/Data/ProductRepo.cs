using OrderService.Model;

namespace OrderService.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product prod)
        {
            _context.Products.Add(prod);
            _context.SaveChanges();
            return prod;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return _context.Products.Where(s => s.Name.Contains(name)).ToList();
        }
    }
}
