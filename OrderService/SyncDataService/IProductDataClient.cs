namespace OrderService.SyncDataService
{
    public interface IProductDataClient
    {
        Task SendProductToInVoice();
    }
}
