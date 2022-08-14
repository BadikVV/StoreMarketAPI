namespace StoreMarketRestAPI.Entities;

public class Product
{
    public string ArticleNumber { get; set; }
    public double Price { get; set; }
    public Nomenclature Nomenclature { get; set; }
    public Warehouse Warehouse { get; set; }
    public Guid Id { get; set; }
}