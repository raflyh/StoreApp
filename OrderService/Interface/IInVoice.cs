using OrderService.Model;

namespace OrderService.Interface
{
    public interface IInVoice
    {
        IEnumerable<InVoice> GetAllInvoice();
        InVoice GetById(int id);
        InVoice GetByName(string name);

    }
}
