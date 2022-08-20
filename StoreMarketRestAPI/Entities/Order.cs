using StoreMarketRestAPI.Base;

namespace StoreMarketRestAPI.Entities;

public class Order : BaseEntity
{
    public OrderStatus Status { get; set; }
    public List<Product> Products { get; set; }
}