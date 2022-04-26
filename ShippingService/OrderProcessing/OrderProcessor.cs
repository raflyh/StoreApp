using AutoMapper;
using ShippingService.Data;
using ShippingService.Dtos;
using ShippingService.EventProcessing;
using ShippingService.Models;
using System.Text.Json;

namespace ShippingService.OrderProcessing
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public OrderProcessor(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void ProcessOrder(string message)
        {
            var orderType = DetermineOrder(message);
            switch (orderType)
            {
                case OrderType.InVoicePublished:
                    AddInVoice(message);
                    break;
                default:
                    break;
            }
        }

        private void AddInVoice(string invoicePublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IShipping>();
                var inVoicePublishedDto = JsonSerializer.Deserialize<InvoicePublishedDto>(invoicePublishedMessage);
                try
                {
                    var inVoice = _mapper.Map<InVoice>(inVoicePublishedDto);
                    if (!repo.ExternalInVoiceExist(inVoice.ExternalID))
                    {
                        repo.CreateInVoice(inVoice);
                        repo.SaveChange();
                        Console.WriteLine("--> Menambahkan InVoice Baru - ShippingService");
                    }
                    else
                    {
                        Console.WriteLine("--> InVoice sudah ada di ShippingService");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Tidak dapat menambahkan InVoice ke database {ex.Message}");
                }
            }

        }

        private OrderType DetermineOrder(string notificationMessage)
        {
            Console.WriteLine("--> Menentukan Order");
            var orderType = JsonSerializer.Deserialize<GenericOrderDto>(notificationMessage);
            switch (orderType.Order)
            {
                case "InVoice_Published":
                    Console.WriteLine("--> InVoice Published Order detected...");
                    return OrderType.InVoicePublished;
                default:
                    Console.WriteLine("--> Can't determined this order...");
                    return OrderType.Undetermined;
            }
        }

    }
    enum OrderType
    {
        InVoicePublished,
        Undetermined
    }
}

