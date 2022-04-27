using AutoMapper;
using ProductService.DTOs;
using ProductService.Models;

namespace ProductService.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryReadDTO>()
                .ForMember(s => s.Products, c => c.MapFrom(x => x.Products));
            CreateMap<CategoryCreateDTO, Category>();
        }
    }
}
