using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.Interface;
using OrderService.Model;
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

        //[HttpGet]
        //public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        //{
        //    Console.WriteLine("--> Ambil product dari order");
        //    var results = _repository.GetAllProducts();
        //    var productReadDto = _mapper.Map<IEnumerable<ProductReadDto>>(results);
        //    return Ok(productReadDto);
        //}

        //[HttpPost]
        //public ActionResult TestInboundConnection()
        //{
        //    Console.WriteLine("----> Inbound Post OrderService");
        //    return Ok("Inbound tes dari product controller");
        //}

        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> Post([FromBody] ProductPublishedDto productPublishedDto)
        {
            try
            {
                var products = _mapper.Map<Product>(productPublishedDto);
                var result = await _repository.CreateProduct(products);
                Console.WriteLine("--> Products succesfully added!");
                return Ok(_mapper.Map<ProductReadDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
