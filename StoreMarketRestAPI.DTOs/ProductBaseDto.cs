namespace StoreMarketRestAPI.DTOs;

public class ProductBaseDto
{
    public string Title { get; set; }
    public string ArticleNumber { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string MeasureUnit { get; set; }
    public string Manufacturer { get; set; }
    public int Quantity { get; set;  }
}