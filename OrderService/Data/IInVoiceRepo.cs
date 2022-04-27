using OrderService.Model;

namespace OrderService.Interface
{
    public interface IInVoiceRepo
    {
        IEnumerable<InVoice> GetAllInvoice();
        InVoice GetOrderById(int id);
        InVoice GetByName(string name);
        void CreateInVoice(InVoice invoice);
        bool SaveChanges();

    }
}
