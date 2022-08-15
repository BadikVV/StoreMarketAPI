using StoreMarketRestAPI.Infrastructure.GenericRepository;
using StoreMarketRestAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using StoreMarketRestAPI.Entities;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DbContext>(options => 
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;"));
builder.Services.AddTransient<IGenericRepository<Nomenclature>,GenericRepository<Nomenclature>>();

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

app.UseCors("DevCorsPolicy");
app.Run();