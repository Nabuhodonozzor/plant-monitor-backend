using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.Services.Base;

namespace PlantMonitorAPI.Services.Interfaces;

public interface ISensorDataService : IServiceBase<SensorData>
{
    Task<IEnumerable<SensorData>> GetPlantSensorData(int plantId, CancellationToken cancellationToken);
}
