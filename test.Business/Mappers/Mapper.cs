using AutoMapper;
using test.Business.Dtos;
using test.Entity.Entities;

namespace test.Business.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //CreateMap<Test, TestDto>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<TestDto, Test>();
        }
    }
}
