using AutoMapper;
using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() //maps one object to another 
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
