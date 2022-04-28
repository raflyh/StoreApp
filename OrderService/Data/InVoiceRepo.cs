

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

        public async Task<Product> CreateProduct(Product prod)
        {

            try
            {
                _context.Products.Add(prod);
                await _context.SaveChangesAsync();
                return prod;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }
            
        public bool ExternalProductExist(int externalProductId)
        {
            //return _context.Products.Any(p=>p.ExternalId == externalProductId);
            return false;
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

        public IEnumerable<InVoice> GetOrderForProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public bool ProductExist(int productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
