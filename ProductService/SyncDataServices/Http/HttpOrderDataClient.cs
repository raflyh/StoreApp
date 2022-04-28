using ProductService.DTOs;
using System.Text;
using System.Text.Json;

namespace ProductService.SyncDataServices.Http
{
    public class HttpOrderDataClient : IOrderDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuraion;

        public HttpOrderDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuraion = configuration;
        }
        public async Task SendProductToOrder(ProductReadDTO product)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_configuraion["OrderService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Success Sending Product to Order Service <--");
            }

            else
            {
                Console.WriteLine("--> Failed Sending Product to Order Service <--");
            }
                
        }
    }
}
