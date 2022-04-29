using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.Interface;
using ProductService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly ICategoryRepo _repository;
        private readonly IMapper _mapper;

        public CatalogsController(ICategoryRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<CatalogsController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            Console.WriteLine("--> Get Products");
            var results = _repository.GetAllCategories();
            var categoryReadDTO = _mapper.Map<IEnumerable<CategoryReadDTO>>(results);
            return Ok(categoryReadDTO);
        }

        [HttpGet("{id}",Name = "GetCategoryById")]
        public ActionResult<CategoryReadDTO> GetCategoryById(int id)
        {
            var results = _repository.GetById(id);
            if (results == null) return NotFound();

            var categoryReadDTO = _mapper.Map<CategoryReadDTO>(results);
            return categoryReadDTO;
        }

        // GET api/<CatalogsController>/5
        [HttpGet("Search/{name}")]
        public ActionResult<IEnumerable<CategoryReadDTO>> SearchCatalog(string name)
        {
            var results = _repository.GetCategoryWithProducts(name);
            var categoryReadDTO = _mapper.Map<CategoryReadDTO>(results);
            if (categoryReadDTO == null)
                return NotFound();
            else
                return Ok(categoryReadDTO);
        }

        // POST api/<CatalogsController>
        [HttpPost]
        public ActionResult<CategoryCreateDTO> CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            var newCategory = _mapper.Map<Category>(categoryCreateDTO);
            _repository.CreateCategory(newCategory);
            _repository.SaveChanges();

            var categoryReadDTO = _mapper.Map<CategoryReadDTO>(newCategory);
            return CreatedAtRoute("GetCategoryById", new { Id = categoryReadDTO.Id }, categoryReadDTO);
        }
    }
}
