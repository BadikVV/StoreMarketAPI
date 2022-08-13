namespace StoreMarketRestAPI.Entities;

public class Product
{
    public string Title { get; set; }
    public string ArticleNumber { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string MeasureUnit { get; set; }
    public string Manufacturer { get; set; }
    public int Quantity { get; set;  }
    public Guid Id { get; set; }
}