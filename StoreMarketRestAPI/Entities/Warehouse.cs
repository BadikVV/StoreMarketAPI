﻿namespace StoreMarketRestAPI.Entities;

public class Warehouse
{
    public string Name { get; set; }
    public string ResponsiblePerson { get; set; }
    public string Adress { get; set; }
    public Guid Id { get; set; }
}