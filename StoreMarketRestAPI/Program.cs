using StoreMarketRestAPI.Infrastructure.GenericRepository;
using StoreMarketRestAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using StoreMarketRestAPI.Entities;
using StoreMarketRestAPI.Infrastructure.Context;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DataDbContext>(options => 
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MarketStore;Trusted_Connection=True;"));
builder.Services.AddTransient<IGenericRepository<Nomenclature>, GenericRepository<Nomenclature>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders();
    });
});



var app = builder.Build();

// Initialising Database (creating tables)
SeedDataDb.Initialize(app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

app.MapControllers();
app.UseCors("DevCorsPolicy");
app.Run();