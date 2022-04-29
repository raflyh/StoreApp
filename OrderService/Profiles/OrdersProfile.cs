using AutoMapper;
using OrderService.Dtos;
using OrderService.Model;

namespace OrderService.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<OrderCreateDto, Order>().ReverseMap();
            CreateMap<Order, OrderReadDto>().ReverseMap();
        }
    }
}
