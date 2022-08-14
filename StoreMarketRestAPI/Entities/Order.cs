namespace StoreMarketRestAPI.Entities;

public class Order
{
    public OrderStatus Status { get; set; }
    public List<Product> Products { get; set; }
    public DateTime RegistrationTime { get; set; }
    public DateTime ReceptionTime { get; set; }
    public Guid Id { get; set; }
}