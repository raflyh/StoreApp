using OrderService.Model;

namespace OrderService.Interface
{
    public interface IInVoiceRepo
    {
        //product
        IEnumerable<InVoice> GetAllProducts();
        Product GetProductById(int id);
        Product GetByName(string name);
        void CreateProduct(InVoice invoice);
        bool SaveChanges();

        //order
        IEnumerable<InVoice> GetOrderForProduct(int productId);
        InVoice GetInVoice(int productId, int inVoiceId);
        void CreateInVoice(int productId, InVoice inVoice);

    }
}
