using AutoMapper;
using ShippingService.Dtos;
using ShippingService.Models;

namespace ShippingService.Profiles
{
    public class ShippingsProfile : Profile
    {
        public ShippingsProfile()
        {
            CreateMap<InVoice, InVoiceReadDto>();
            CreateMap<Shipping, ShippingReadDto>();
            CreateMap<ShippingCreateDto, Shipping>();
            CreateMap<InVoicePublishedDto, InVoice>().ForMember(dest => dest.ExternalID,
                opt => opt.MapFrom(src => src.Id));
        }
        
    }
}
