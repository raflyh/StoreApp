using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.AsyncDataService;
using OrderService.Dtos;
using OrderService.Interface;
using OrderService.Model;
using OrderService.SyncDataService;

namespace OrderService.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IInVoiceRepo _repository;
        private readonly IMapper _mapper;
        private readonly IProductDataClient _productDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public OrderController(IInVoiceRepo repository, IMapper mapper,
        IProductDataClient productDataClient, IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _productDataClient = productDataClient;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetInvoices()
        {
            Console.WriteLine("--> Get Order");
            var results = _repository.GetAllInvoice();
            var orderReadDtos = _mapper.Map<IEnumerable<OrderReadDto>>(results);
            return Ok(orderReadDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            var results = _repository.GetOrderById(id);
            if (results == null) return NotFound();

            var orderReadDto = _mapper.Map<OrderReadDto>(results);
            return orderReadDto;
        }

        [HttpGet("{CodeInVoice}")]
        public ActionResult<OrderReadDto> GetByName(string name)
        {
            var results = _repository.GetByName(name);
            if (results == null) return NotFound();

            var orderReadDto = _mapper.Map<OrderReadDto>(results);
            return orderReadDto;
        }


        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreatePlatform(OrderCreateDto orderCreateDto)
        {
            var newOrder = _mapper.Map<InVoice>(orderCreateDto);
            _repository.CreateInVoice(newOrder);
            _repository.SaveChanges();

            var orderReadDto = _mapper.Map<OrderReadDto>(newOrder);

            
            try
            {
                var orderPublishDto = _mapper.Map<OrderPublishDto>(orderReadDto);
                orderPublishDto.Order = "Order_Published";
                _messageBusClient.PublishNewInVoice(orderPublishDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Tidak dapat mengirimkan async message {ex.Message}");
            }

            return CreatedAtAction(nameof(GetOrderById), new { Id = orderReadDto.Id },
                orderReadDto);
        }
    }*/
}
