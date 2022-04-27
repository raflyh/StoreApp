using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingService.Data;
using ShippingService.Dtos;
using ShippingService.Models;

namespace ShippingService.Controllers
{
    [Route("api/Shipping/Orders/{OrderById}/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly ShippingRepo _repository;
        private readonly IMapper _mapper;

        public ShippingsController(ShippingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShippingReadDto>> GetShippingsForInVoice(int inVoiceId)
        {
            Console.WriteLine($"----> Semua Shipping dari invoice {inVoiceId}");
            if (!_repository.InVoiceExist(inVoiceId)) ;
            return NotFound();

            var shippings = _repository.GetShippingForInVoice(inVoiceId);
            var shippingReadDto = _mapper.Map<IEnumerable<ShippingReadDto>>(shippings);
            return Ok(shippingReadDto);
        }

        [HttpGet("{ShippingId}")]
        public ActionResult<ShippingReadDto> GetShippingForInVoice(int invoiceId, int shippingId)
        {
            Console.WriteLine($"--> Satu shipping dari invoice {invoiceId} / {shippingId}");
            if (!_repository.InVoiceExist(invoiceId))
                return NotFound();

            var shipping = _repository.GetShipping(invoiceId, shippingId);
            if (shipping == null) return NotFound();

            return Ok(_mapper.Map<ShippingReadDto>(shipping));
        }

        [HttpPost]
        public ActionResult<ShippingReadDto> CreateShippingForInVoice(int invoiceId,
            ShippingCreateDto shippingCreateDto)
        {
            Console.WriteLine($"--> Menambahkan shipping untuk invoice {invoiceId}");

            if (!_repository.InVoiceExist(invoiceId))
                return NotFound();

            var shipping = _mapper.Map<Shipping>(shippingCreateDto);
            _repository.CreateShipping(invoiceId, shipping);
            _repository.SaveChange();

            var shippingReadDto = _mapper.Map<ShippingReadDto>(shipping);

            return CreatedAtAction(nameof(GetShippingForInVoice),
                new { invoiceId = invoiceId, shippingId = shippingReadDto.Id },
                    shippingReadDto);
        }
    }
}
