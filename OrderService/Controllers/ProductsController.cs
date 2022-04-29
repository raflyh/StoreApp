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
        private readonly IProductRepo _repo1;

        public ProductsController(IMapper mapper, IProductRepo repo1)
        {
            
            _mapper = mapper;
            _repo1 = repo1;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        {
            Console.WriteLine("--> Getting Products --<");
            var results = _repo1.GetAllProducts();
            var productReadDto = _mapper.Map<IEnumerable<ProductReadDto>>(results);
            return Ok(productReadDto);
        }
        [HttpPost]
        public ActionResult PushProduct(ProductCreateDto productCreateDTO)
        {
            //Console.WriteLine("----> Inbound Post OrderService");
            //return Ok("Inbound tes dari product controller");
            var product = _mapper.Map<Product>(productCreateDTO);
            var result = _repo1.CreateProduct(product);
            Console.WriteLine("--> Products succesfully added!");
            var newproduct = _mapper.Map<ProductReadDto>(result);
            return Ok(newproduct);
        }

    }
}
