

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
            if (inVoice == null)
                throw new ArgumentNullException(nameof(inVoice));
            _context.Add(inVoice);
        }

        public void CreateProduct(InVoice invoice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InVoice> GetAllProducts()
        {
            return _context.InVoices.AsNoTracking().ToList();
        }

        public Product GetByName(string name)
        {
            return _context.Products.Where(s => s.Name.Contains(name)).FirstOrDefault();
        }

        public InVoice GetInVoice(int productId, int inVoiceId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InVoice> GetOrderForProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(i => i.Id == id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
