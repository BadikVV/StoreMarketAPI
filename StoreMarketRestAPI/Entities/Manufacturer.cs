using StoreMarketRestAPI.Base;
namespace StoreMarketRestAPI.Entities;

public class Manufacturer : BaseEntity
{
    public string Name { get; set; }
    public string Country { get; set; }
}