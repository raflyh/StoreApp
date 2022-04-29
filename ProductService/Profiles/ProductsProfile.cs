using AutoMapper;
using ProductService.DTOs;
using ProductService.Models;

namespace ProductService.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDTO>();
            CreateMap<Product, ProductPushDTO>();
            CreateMap<ProductCreateDTO, Product>();
        }
    }
}
