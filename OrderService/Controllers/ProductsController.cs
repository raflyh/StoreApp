using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Dtos;
using OrderService.Interface;
using OrderService.Model;

namespace OrderService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductRepo _repository;

        public ProductsController(IMapper mapper, IProductRepo repository)
        {
            
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        {
            Console.WriteLine("--> Getting Products --<");
            var results = _repository.GetAllProducts();
            var productReadDto = _mapper.Map<IEnumerable<ProductReadDto>>(results);
            return Ok(productReadDto);
        }
        [HttpPost]
        public ActionResult PushProduct(ProductReadDto productReadDto)
        {
            //Console.WriteLine("----> Inbound Post OrderService");
            //return Ok("Inbound tes dari product controller");
            var product = _mapper.Map<Product>(productReadDto);
            var result = _repository.CreateProduct(product);
            Console.WriteLine("--> Products succesfully added!");
            var newproduct = _mapper.Map<ProductReadDto>(product);
            return Ok(newproduct);
        }

    }
}
