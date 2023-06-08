using AutoMapper;
using Entities.Concrete;
using WebAPI.DTOs;

namespace WebAPI
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
