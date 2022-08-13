namespace StoreMarketRestAPI.DTOs;

public class OrderBaseDto
{
    public OrderStatus Status { get; set; }
    public string Title { get; set; }
    public int Quanity { get; set; }
    public DateTime RegistrationTime { get; set; }
    public DateTime ReceptionTime { get; set; }
}