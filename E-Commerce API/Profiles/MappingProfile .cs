using AutoMapper;
using E_Commerce_API.DTO;
using E_Commerce_API.Models;

namespace E_Commerce_API.Profiles
{
    public class MappingProfile:Profile
    {
     public MappingProfile() 
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateProductDto, Product>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
