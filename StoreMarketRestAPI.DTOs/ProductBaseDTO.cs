namespace StoreMarketRestAPI.DTOs;

public class ProductBaseDTO
{
    public string ArticleNumber { get; set; }
    public double Price { get; set; }
    public NomenclatureDTO Nomenclature { get; set; }
    public WarehouseDTO Warehouse { get; set; }
}