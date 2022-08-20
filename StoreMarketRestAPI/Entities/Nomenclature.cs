using StoreMarketRestAPI.Base;
namespace StoreMarketRestAPI.Entities;

public class Nomenclature : BaseEntity
{
    public string Name { get; set; }
    public string Category { get; set; }
    private string MeasureUnit { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public int Quantity { get; set; }
}
