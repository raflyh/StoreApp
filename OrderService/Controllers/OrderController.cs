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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IInVoiceRepo _repository;
        private readonly IMapper _mapper;

        public OrderController(IInVoiceRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetOrderForProduct(int platformId)
        {
            Console.WriteLine($"----> Semua Order dari product {platformId}");
            if (!_repository.ProductExist(platformId)) ;
            return NotFound();

            var orders = _repository.GetOrderForProduct(platformId);
            var orderReadDto = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return Ok(orderReadDto);
        }

        [HttpGet("{OrderId}")]
        public ActionResult<OrderReadDto> GetOrderForProduct(int productId, int inVoiceId)
        {
            Console.WriteLine($"--> Satu shipping dari invoice {productId} / {inVoiceId}");
            if (!_repository.ProductExist(productId))
                return NotFound();

            var order = _repository.GetInVoice(productId, inVoiceId);
            if (order == null) return NotFound();

            return Ok(_mapper.Map<OrderReadDto>(order));
        }

        [HttpGet("GetByName")]
        public ActionResult<ProductReadDto> GetProductByName(string name)
        {
            Console.WriteLine($"----> satu shipping dengan CodeInvoice {name}");

            var order = _repository.GetProductByName(name);
            if (order == null) return NotFound();

            return Ok(_mapper.Map<ProductReadDto>(order));
        }

    }
}
