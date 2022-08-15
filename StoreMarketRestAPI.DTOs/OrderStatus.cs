namespace StoreMarketRestAPI.DTOs;

public enum OrderStatus 
{
    WaitingForPayment,
    AcceptedForExecution,
    Executed,
    Given,
    Refund
}