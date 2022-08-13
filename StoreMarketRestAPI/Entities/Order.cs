namespace StoreMarketRestAPI.Entities;

public class Order
{
    public OrderStatus Status { get; set; }
    public string Title { get; set; }
    public int Quanity { get; set; }
    public DateTime RegistrationTime { get; set; }
    public DateTime ReceptionTime { get; set; }
    public Guid Id { get; set; }
}