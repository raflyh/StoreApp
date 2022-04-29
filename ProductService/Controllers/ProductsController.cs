using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.Interface;
using ProductService.Models;
using ProductService.SyncDataServices.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;
        private readonly IOrderDataClient _orderDataClient;

        public ProductsController(IProductRepo repository, IMapper mapper, IOrderDataClient orderDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _orderDataClient = orderDataClient;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetProducts()
        {
            Console.WriteLine("--> Get Products");
            var results = _repository.GetAllProducts();
            var productReadDTO = _mapper.Map<IEnumerable<ProductReadDTO>>(results);
            return Ok(productReadDTO);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDTO> GetProductById(int id)
        {
            var results = _repository.GetById(id);
            if (results == null) return NotFound();

            var productReadDTO = _mapper.Map<ProductReadDTO>(results);
            return productReadDTO;
        }

        [HttpGet("Search/{name}")]
        public ActionResult<IEnumerable<ProductReadDTO>> SearchProduct(string name)
        {
            var results = _repository.GetProductByName(name);
            var productReadDTO = _mapper.Map<ProductReadDTO>(results);
            if (productReadDTO == null)
                return NotFound();
            else
                return Ok(productReadDTO);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductCreateDTO>> CreateProduct(ProductCreateDTO productCreateDTO)
        {
            var newProduct = _mapper.Map<Product>(productCreateDTO);
            _repository.CreateProduct(newProduct);
            _repository.SaveChanges();

            var productReadDTO = _mapper.Map<ProductReadDTO>(newProduct);
            var post = new ProductPushDTO
            {
                Name = productCreateDTO.Name,
                Price = productCreateDTO.Price
            };

            await _orderDataClient.SendProductToOrder(post);

            return CreatedAtRoute("GetProductById", new { Id=productReadDTO.Id }, productReadDTO);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult<ProductCreateDTO> Put(int id, ProductCreateDTO productCreateDTO)
        {
            var updateProduct = _mapper.Map<Product>(productCreateDTO);
            var result = _repository.UpdateProduct(id, updateProduct);
            var productReadDTO = _mapper.Map<ProductReadDTO>(result);
            return Ok(productReadDTO);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.RemoveProduct(id);
        }
    }
}
