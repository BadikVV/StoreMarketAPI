using StoreMarketRestAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace StoreMarketRestAPI.Infrastructure.Context;

public sealed class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) {
        
    }
    public DbSet<Nomenclature> Nomenclatures { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}