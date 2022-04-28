using OrderService.Model;

namespace OrderService.Interface
{
    public interface IInVoiceRepo
    {
        bool SaveChanges();
        //product
        IEnumerable<Product> GetAllProducts();
        Product GetProductByName(string name);
        Product GetProductById(int id);
        Product CreateProduct(Product prod);

        

        //order
        //IEnumerable<InVoice> GetOrderForProduct(int productId);
        InVoice GetInVoice(int productId, int inVoiceId);
        void CreateInVoice(int productId, InVoice inVoice);

    }
}
