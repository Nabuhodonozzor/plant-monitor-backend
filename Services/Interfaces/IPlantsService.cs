using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.Services.Base;

namespace PlantMonitorAPI.Services.Interfaces;

public interface IPlantsService : IServiceBase<Plant>
{
    Task AddPlant(Plant plant, CancellationToken cancellationToken);
}
