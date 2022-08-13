namespace StoreMarketRestAPI.Entities;

public enum OrderStatus 
{
    WaitingForPayment,
    AcceptedForExecution,
    Executed,
    Given,
    Refund
}