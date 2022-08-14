
namespace StoreMarketRestAPI.Entities;

public class Nomenclature
{
    public string Name { get; set; }
    public string Category { get; set; }
    private string MeasureUnit { get; set; }
    public Manufacture Manufacture { get; set; }
    public int Quantity { get; set; }
}
