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
                .ForMember(s => s.productReadDTOs, c => c.MapFrom(x => x.Products));
            CreateMap<CategoryCreateDTO, Category>();
        }
    }
}
