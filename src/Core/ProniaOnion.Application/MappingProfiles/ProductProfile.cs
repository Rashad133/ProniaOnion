using AutoMapper;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductItemDto>().ReverseMap();
            CreateMap<Product,ProductGetDto>().ReverseMap();
            CreateMap<ProductCreateDto,Product>();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}
