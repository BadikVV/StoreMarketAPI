namespace StoreMarketRestAPI.DTOs;
using StoreMarketRestAPI;
public class OrderBaseDTO
{
    public OrderStatus Status { get; set; }
    public List<ProductDTO> Products { get; set; }
    public DateTime RegistrationTime { get; set; }
    public DateTime ReceptionTime { get; set; }
}