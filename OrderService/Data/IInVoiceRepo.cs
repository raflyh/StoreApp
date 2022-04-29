using OrderService.Model;

namespace OrderService.Interface
{
    public interface IInVoiceRepo
    {
        bool SaveChanges();
        //product
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(Product prod);

        

        //order
        IEnumerable<InVoice> GetAllInVoices();
        //InVoice GetInVoice(int productId, int inVoiceId);
        void CreateInVoice(int productId, InVoice inVoice);
        InVoice GetOrderById(int id);
        InVoice GetOrderByName(string name);

    }
}
