using OrderService.Model;

namespace OrderService.Interface
{
    public interface IInVoiceRepo
    {
        bool SaveChanges();
        //product
        IEnumerable<Product> GetAllProducts();
        Product GetProductByName(string name);
        void CreateProduct(Product prod);
        bool ProductExist(int productId);
        bool ExternalProductExist(int externalProductId);
        

        //order
        //IEnumerable<InVoice> GetOrderForProduct(int productId);
        InVoice GetInVoice(int productId, int inVoiceId);
        void CreateInVoice(int productId, InVoice inVoice);

    }
}
