using OrderService.Dtos;

namespace OrderService.AsyncDataService
{
    public interface IMessageBusClient
    {
        void PublishNewOrder(OrderPublishDto orderPublishDto);
    }
}
