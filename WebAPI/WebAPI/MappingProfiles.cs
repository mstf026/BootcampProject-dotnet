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
            CreateMap<Subpiece, SubpieceDto>();
            CreateMap<SubpieceDto, Subpiece>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
        }
    }
}
