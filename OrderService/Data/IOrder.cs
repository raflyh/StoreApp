using OrderService.Model;

namespace OrderService.Interface
{
    public interface IOrder
    {
        bool SaveChanges();
        //product


        

        //order
        IEnumerable<Order> GetAllInVoices();
        //InVoice GetInVoice(int productId, int inVoiceId);
        void CreateInVoice( Order inVoice);
        Order GetOrderById(int id);
        Order GetOrderByName(string name);

    }
}
