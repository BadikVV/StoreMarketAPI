using AutoMapper;
using StoreMarketRestAPI.DTOs;
using StoreMarketRestAPI.Entities;

namespace StoreMarketRestAPI.Mappings;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<ProductCreateDTO, Product>().ReverseMap();
        CreateMap<ProductUpdateDTO, Product>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}