using AutoMapper;
using ShippingService.Data;
using ShippingService.Dtos;
using ShippingService.EventProcessing;
using ShippingService.Models;
using System.Text.Json;

namespace ShippingService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void ProcessEvent(string message)
        {
            var EventType = DetermineEvent(message);
            switch (EventType)
            {
                case EventType.InVoicePublished:
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

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Menentukan Event");
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);
            switch (eventType.Event)
            {
                case "InVoice_Published":
                    Console.WriteLine("--> InVoice Published Event detected...");
                    return EventType.InVoicePublished;
                default:
                    Console.WriteLine("--> Can't determined this Event...");
                    return EventType.Undetermined;
            }
        }

    }
    enum EventType
    {
        InVoicePublished,
        Undetermined
    }
}

