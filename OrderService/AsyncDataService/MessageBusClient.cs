using OrderService.Dtos;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderService.AsyncDataService
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
                Console.WriteLine("--> Terkoneksi ke Message Bus RabbitMQ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Tidak bisa connect ke Message Bus {ex.Message}");
            }
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> RabbitMQ Connection Shutdown");
        }

        public void PublishNewOrder(OrderPublishDto orderPublishDto)
        {
            var message = JsonSerializer.Serialize(orderPublishDto);
            if (_connection.IsOpen)
            {
                Console.WriteLine("--> RabbitMQ Connection Open, kirim pesan...");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("--> RabbitMQ connection closed, tidak bisa kirim pesan");
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Message Bus Disposed");
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger", routingKey: "",
                basicProperties: null, body: body);
            Console.WriteLine($"--> Sudah mengirimkan pesan {message}");
        }
    }
}
