using OrderService.Dtos;

namespace OrderService.AsyncDataService
{
    public interface IMessageBusClient
    {
        void PublishNewInVoice(OrderPublishDto orderPublishDto);
    }
}
