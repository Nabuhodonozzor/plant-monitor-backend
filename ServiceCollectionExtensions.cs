using PlantMonitorAPI.Services;
using PlantMonitorAPI.Services.Interfaces;

namespace PlantMonitorAPI;

public static class SerivceCollectionExtensions
{
    public static IServiceCollection ConfigureRequests(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        return services;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IPlantsService, PlantsService>();
        services.AddScoped<ISensorDataService, SensorDataService>();

        return services;
    }
}
