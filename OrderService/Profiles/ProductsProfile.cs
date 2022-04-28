﻿using AutoMapper;
using OrderService.Dtos;
using OrderService.Model;

namespace OrderService.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
