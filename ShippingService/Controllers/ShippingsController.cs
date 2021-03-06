using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingService.Data;
using ShippingService.Dtos;
using ShippingService.Models;

namespace ShippingService.Controllers
{
    [Route("api/s/inVoices/{inVoiceId}/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly IShipping _repository;
        private readonly IMapper _mapper;

        public ShippingsController(IShipping repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShippingReadDto>> GetShippingsForInVoice(int inVoiceId)
        {
            Console.WriteLine($"----> Semua Shipping dari invoice {inVoiceId}");
            if (!_repository.InVoiceExist(inVoiceId));
            return NotFound();

            var shippings = _repository.GetShippingForInVoice(inVoiceId);
            var shippingReadDto = _mapper.Map<IEnumerable<ShippingReadDto>>(shippings);
            return Ok(shippingReadDto);
        }

        [HttpGet("{ShippingId}")]
        public ActionResult<ShippingReadDto> GetShippingForInVoice(int inVoiceId, int shippingId)
        {
            Console.WriteLine($"--> Satu shipping dari invoice {inVoiceId} / {shippingId}");
            if (!_repository.InVoiceExist(inVoiceId))
                return NotFound();

            var shipping = _repository.GetShipping(inVoiceId, shippingId);
            if (shipping == null) return NotFound();

            return Ok(_mapper.Map<ShippingReadDto>(shipping));
        }

        [HttpGet("{CodeInVoice}")]
        public ActionResult<InvoiceReadDto> GetShippingForCodeInVoice(int inVoiceId)
        {
            Console.WriteLine($"----> satu shipping dengan CodeInvoice {inVoiceId}");

            var shipping = _repository.GetShippingForInVoice(inVoiceId);
            if (shipping == null) return NotFound();

            return Ok(_mapper.Map<InvoiceReadDto>(shipping));
        }

        [HttpPost]
        public ActionResult<ShippingReadDto> CreateShippingForInVoice(int inVoiceId,
            ShippingCreateDto shippingCreateDto)
        {
            Console.WriteLine($"--> Menambahkan shipping untuk invoice {inVoiceId}");

            if (!_repository.InVoiceExist(inVoiceId))
                return NotFound();

            var shipping = _mapper.Map<Shipping>(shippingCreateDto);
            _repository.CreateShipping(inVoiceId, shipping);
            _repository.SaveChange();

            var shippingReadDto = _mapper.Map<ShippingReadDto>(shipping);

            return CreatedAtAction(nameof(GetShippingForInVoice),
                new { inVoiceId = inVoiceId, shippingId = shippingReadDto.Id },
                    shippingReadDto);
        }
    }
}
