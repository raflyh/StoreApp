using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.Interface;
using OrderService.Model;

namespace OrderService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IInVoiceRepo _repo;
        private readonly IMapper _mapper;

        public ProductsController(IInVoiceRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        {
            Console.WriteLine("--> Getting Products --<");
            var results = _repo.GetAllProducts();
            var productReadDto = _mapper.Map<IEnumerable<ProductReadDto>>(results);
            return Ok(productReadDto);
        }
        [HttpPost]
        public ActionResult TestInboundConnection(ProductCreateDto productCreateDTO)
        {
            //Console.WriteLine("----> Inbound Post OrderService");
            //return Ok("Inbound tes dari product controller");
            var product = _mapper.Map<Product>(productCreateDTO);
            var result = _repo.CreateProduct(product);
            Console.WriteLine("--> Products succesfully added!");
            var newproduct = _mapper.Map<ProductReadDto>(result);
            return Ok(newproduct);
        }
    }
}
