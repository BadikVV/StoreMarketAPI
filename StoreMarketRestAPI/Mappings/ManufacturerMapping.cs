using AutoMapper;
using StoreMarketRestAPI.Entities;
using StoreMarketRestAPI.DTOs;

namespace StoreMarketRestAPI.Mappings;

public class ManufacturerMapping : Profile
{
    public ManufacturerMapping()
    {
        CreateMap<ManufacturerCreateDTO, Manufacturer>().ReverseMap();
        CreateMap<ManufacturerUpdateDTO, Manufacturer>().ReverseMap();
        CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
        CreateMap<ManufacturerBaseDTO, Manufacturer>().ReverseMap();
    }
}