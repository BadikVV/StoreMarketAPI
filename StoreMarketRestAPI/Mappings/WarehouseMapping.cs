using AutoMapper;
using StoreMarketRestAPI.DTOs;
using StoreMarketRestAPI.Entities;

namespace StoreMarketRestAPI.Mappings;

public class WarehouseMapping : Profile
{
    public WarehouseMapping()
    {
        CreateMap<WarehouseCreateDTO, Warehouse>().ReverseMap();
        CreateMap<WarehouseUpdateDTO, Warehouse>().ReverseMap();
        CreateMap<Warehouse, WarehouseDTO>().ReverseMap();
    }
}