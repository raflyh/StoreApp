

using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderService.Interface;
using OrderService.Model;

namespace OrderService.Data
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;

        public OrderRepo(AppDbContext context)
        {
            _context = context;
        }

        public Order CreateOrder( Order order, Product product) //Product, bukan InVoice
        {
            var checkproduct = _context.Products.Where(product => product.Quantity>0);
            if (checkproduct == null)
                throw new ArgumentNullException(nameof(checkproduct));
            else
                order.TotalCost.Equals(product.Quantity * product.Price);
                _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
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

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
