
namespace StoreMarketRestAPI.Entities;

public class Nomenclature
{
    public string Name { get; set; }
    public string Category { get; set; }
    private string MeasureUnit { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public int Quantity { get; set; }
    public Guid Id { get; set; }
}
