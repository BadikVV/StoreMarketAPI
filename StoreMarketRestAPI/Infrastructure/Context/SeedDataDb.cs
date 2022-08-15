namespace StoreMarketRestAPI.Infrastructure.Context;

public class SeedDataDb
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<DataDbContext>();
        context.Database.EnsureCreated();
    }
}

