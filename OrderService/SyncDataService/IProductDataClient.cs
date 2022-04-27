using OrderService.Dtos;

namespace OrderService.SyncDataService
{
    public interface IProductDataClient
    {
        Task SendProductToInVoice(OrderReadDto orderRead);
    }
}
