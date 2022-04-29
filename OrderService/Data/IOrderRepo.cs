using OrderService.Model;

namespace OrderService.Interface
{
    public interface IOrderRepo
    {
        bool SaveChanges();
        //order
        IEnumerable<Order> GetOrders();
        //IEnumerable<Product> GetProducts();
        //InVoice GetInVoice(int productId, int inVoiceId);
        void CreateOrder( Order order);
        Order GetOrderById(int id);
        //Order GetOrderByName(string name);

    }
}
