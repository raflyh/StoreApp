using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingService.Data;
using ShippingService.Dtos;

namespace ShippingService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class InVoicesController : ControllerBase
    {
        private readonly IShipping _repository;
        private readonly IMapper _mapper;

        public InVoicesController(IShipping repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvoiceReadDto>> GetInvoice()
        {
            Console.WriteLine("--> Ambil invoice dari Shipping Service");
            var results = _repository.GetAllInVoices();
            var invoiceReadDto = _mapper.Map<IEnumerable<InvoiceReadDto>>(results);
            return Ok(invoiceReadDto);
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST ShippingService");
            return Ok("Inbound test dari Invoice Controller");
        }
    }
}
