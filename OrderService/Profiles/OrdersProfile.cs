using AutoMapper;
using OrderService.Dtos;
using OrderService.Model;

namespace OrderService.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<OrderCreateDto, InVoice>();
            CreateMap<InVoice, OrderReadDto>();
            CreateMap<ProductPublishedDto, Product>();

           
            

        }
    }
}
