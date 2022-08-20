using StoreMarketRestAPI.Base;

namespace StoreMarketRestAPI.Entities;

public class Warehouse : BaseEntity
{
    public string Name { get; set; }
    public string ResponsiblePerson { get; set; }
    public string Adress { get; set; }
}