

using Microsoft.EntityFrameworkCore;
using OrderService.Interface;
using OrderService.Model;

namespace OrderService.Data
{
    public class InVoiceRepo : IInVoiceRepo
    {
        private readonly AppDbContext _context;

        public InVoiceRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateInVoice(int productId, InVoice inVoice)
        {
            if(inVoice == null)
                throw new ArgumentNullException(nameof(inVoice));

            inVoice.ProductId = productId;
            _context.InVoices.Add(inVoice);
        }

        public Product CreateProduct(Product prod)
        {
            if(prod == null)
                throw new ArgumentNullException(nameof(prod));
            _context.Categories.Add(prod.Category);
            _context.Products.Add(prod);
            _context.SaveChanges();
            return prod;
        }
            
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public InVoice GetInVoice(int productId, int inVoiceId)
        {
            return _context.InVoices.Where(i => i.ProductId == productId &&
            i.Id == inVoiceId).FirstOrDefault(); ;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
