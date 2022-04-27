using AutoMapper;
using ShippingService.Dtos;
using ShippingService.Models;

namespace ShippingService.Profiles
{
    public class ShippingsProfile : Profile
    {
        public ShippingsProfile()
        {
            CreateMap<InVoice, InvoiceReadDto>();
            CreateMap<Shipping, ShippingReadDto>();
            CreateMap<ShippingCreateDto, Shipping>();
            CreateMap<InvoicePublishedDto, InVoice>().ForMember(dest => dest.ExternalID,
                opt => opt.MapFrom(src => src.Id));
        }
    }
}
