namespace StoreMarketRestAPI.DTOs;

public class NomenclatureBaseDTO
{
    public string Name { get; set; }
    public string Category { get; set; }
    private string MeasureUnit { get; set; }
    public ManufacturerBaseDTO Manufacturer { get; set; }
    public int Quantity { get; set; }
}