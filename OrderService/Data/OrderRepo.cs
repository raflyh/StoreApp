

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

        public void CreateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            _context.Add(order);
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(p => p.Id == id);
        }

        /*public Order GetOrderByName(string name)
        {
            return _context.Orders.FirstOrDefault(i => i.CodeInVoice == name);
        }*/

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.AsNoTracking().ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
