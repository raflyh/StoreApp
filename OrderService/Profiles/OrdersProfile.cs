using AutoMapper;
using OrderService.Dtos;
using OrderService.Model;

namespace OrderService.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<InVoice, OrderReadDto>();
            CreateMap<OrderCreateDto, InVoice>();
            CreateMap<OrderReadDto, OrderPublishDto>();

        }
    }
}
