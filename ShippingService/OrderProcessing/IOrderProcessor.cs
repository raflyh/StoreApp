namespace ShippingService.EventProcessing
{
    public interface IOrderProcessor
    {
        void ProcessOrder(string message);
    }
}
