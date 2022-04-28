using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.Interface;
using ProductService.DTOs;

namespace OrderService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IInVoiceRepo _repository;
        private readonly IMapper _mapper;

        public ProductsController(IInVoiceRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        {
            Console.WriteLine("--> Ambil product dari order");
            var results = _repository.GetAllProducts();
            var productReadDto = _mapper.Map<IEnumerable<ProductReadDto>>(results);
            return Ok(productReadDto);
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("----> Inbound Post OrderService");
            return Ok("Inbound tes dari product controller");
        }
    }
}
