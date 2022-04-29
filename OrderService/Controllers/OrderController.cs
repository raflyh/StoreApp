using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.AsyncDataService;
using OrderService.Dtos;
using OrderService.Interface;
using OrderService.Model;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _repository;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public OrderController(IOrderRepo repository, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }
        /*[HttpPost]
        public ActionResult<OrderCreateDto> CreateOrder(OrderCreateDto orderCreateDto, ProductReadDto productReadDto)
        {
            Console.WriteLine("--> Creating Orders --<");
            var product = _mapper.Map<Product>(productReadDto);
            var order = _mapper.Map<Order>(orderCreateDto);
            var result = _repository.CreateOrder(order, product);
            var neworder = _mapper.Map<OrderReadDto>(result);
            return Ok(neworder);
        }*/
        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetOrder()
        {
            Console.WriteLine("--> Getting Invoices --<");
            var results = _repository.GetOrders();
            var orderReadDto = _mapper.Map<IEnumerable<OrderReadDto>>(results);
            return Ok(orderReadDto);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderReadDto> GetOrderById(int orderId)
        {
            Console.WriteLine($"----> satu InVoice dari Product {orderId}");

            var order = _repository.GetOrderById(orderId);
            if (order == null) return NotFound();

            return Ok(_mapper.Map<OrderReadDto>(order)); 
        }

        /*[HttpGet("GetByName")]
        public ActionResult<OrderReadDto> GetInVoiceByName(string name)
        {
            Console.WriteLine($"----> satu shipping dengan CodeInvoice {name}");

            var order = _repository.GetOrderByName(name);
            if (order == null) return NotFound();

            return Ok(_mapper.Map<OrderReadDto>(order)); //seharusnya bukan memanggil DTO Produk, harusnya invoice dengan namaproduk
        }*/

        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var newOrder = _mapper.Map<Order>(orderCreateDto);
            _repository.CreateOrder(newOrder);
            _repository.SaveChanges();

            var orderReadDto = _mapper.Map<OrderReadDto>(newOrder);


            //kirim async
            try
            {
                var orderPublishDto = _mapper.Map<OrderPublishDto>(orderReadDto);
                orderPublishDto.Event = "Order_Published";
                _messageBusClient.PublishNewOrder(orderPublishDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Tidak dapat mengirimkan async message {ex.Message}");
            }

            return CreatedAtAction(nameof(GetOrderById), new { Id = orderReadDto.Id },
                orderReadDto);
        }

    }
}
