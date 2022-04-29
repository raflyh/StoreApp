namespace ShippingService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
