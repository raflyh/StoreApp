

using Microsoft.EntityFrameworkCore;
using OrderService.Interface;
using OrderService.Model;

namespace OrderService.Data
{
    public class InVoiceRepo : IOrder
    {
        private readonly AppDbContext _context;

        public InVoiceRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateInVoice( Order inVoice) //Product, bukan InVoice
        {
            if(inVoice == null)
                throw new ArgumentNullException(nameof(inVoice));

            
            _context.Orders.Add(inVoice);
        }

        public Product CreateProduct(Product prod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllInVoices()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        /*public InVoice GetInVoice(int productId, int inVoiceId)
        {
            return _context.InVoices.Where(i => i.ProductId == productId &&
            i.Id == inVoiceId).FirstOrDefault(); ;
        }*/

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(i => i.Id == id);
        }

        public Order GetOrderByName(string name)
        {
            return _context.Orders.FirstOrDefault(i => i.CodeInVoice == name);
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
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
