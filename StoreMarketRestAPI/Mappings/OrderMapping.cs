using AutoMapper;
using StoreMarketRestAPI.DTOs;
using StoreMarketRestAPI.Entities;

namespace StoreMarketRestAPI.Mappings;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<OrderCreateDTO, Order>().ReverseMap();
        CreateMap<OrderUpdateDTO, Order>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
    }
}