using OrderService.Model;

namespace OrderService.Interface
{
    public interface IInVoiceRepo
    {
        bool SaveChanges();
        //product


        

        //order
        IEnumerable<InVoice> GetAllInVoices();
        //InVoice GetInVoice(int productId, int inVoiceId);
        void CreateInVoice( InVoice inVoice);
        InVoice GetOrderById(int id);
        InVoice GetOrderByName(string name);

    }
}
