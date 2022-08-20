using StoreMarketRestAPI.Base;

namespace StoreMarketRestAPI.Entities;

public class Product : BaseEntity
{
    public string ArticleNumber { get; set; }
    public double Price { get; set; }
    public Nomenclature Nomenclature { get; set; }
    public Warehouse Warehouse { get; set; }
}