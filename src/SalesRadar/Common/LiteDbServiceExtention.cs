using Microsoft.Extensions.DependencyInjection;
using SalesRadar.Infrastruture;

namespace SalesRadar.Common;

public static class LiteDbServiceExtention
{
    public static void AddLiteDb(this IServiceCollection services, string databasePath)
    {
        services.AddScoped<SalesRadarLiteDbContext>();
        services.Configure<LiteDbConfig>(options => options.DatabasePath=databasePath);
    }
}
