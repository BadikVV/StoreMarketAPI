using System.Reflection;
using StoreMarketRestAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using StoreMarketRestAPI.Entities;
using StoreMarketRestAPI.Infrastructure.Context;
using StoreMarketRestAPI.Infrastructure.Generics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DataDbContext>(options => 
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MarketStore;Trusted_Connection=True;"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IGenericRepository, GenericRepository>();
builder.Services.AddTransient<GenericService>();

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