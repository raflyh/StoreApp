using OrderService.Dtos;
using System.Text;
using System.Text.Json;

namespace OrderService.SyncDataService
{
    public class HttpProductDataClient : IProductDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpProductDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendProductToInVoice(OrderReadDto orderRead)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(orderRead),
            Encoding.UTF8, "apllication/json");

            var response = await _httpClient.PostAsync($"{_configuration["ProductService"]}",
                httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST ke ProductService berhasil dikirimkan");
            }
            else
            {
                Console.WriteLine("--> Sync POST ke ProductServices gagal dikirimkan");
            }
        }
    }
}
