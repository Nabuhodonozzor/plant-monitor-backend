namespace PlantMonitorAPI.Services;

using System.Data.Entity;
using PlantMonitorAPI.Database;
using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.Services.Base;
using PlantMonitorAPI.Services.Interfaces;

public class SensorDataService(PlantMonitorDBContext context) : ServiceBase<SensorData>(context), ISensorDataService
{
    public async Task<IEnumerable<SensorData>> GetPlantSensorData(int plantId, CancellationToken cancellationToken)
    {
        return await this.EntitiesQuery.Where(sd => sd.PlantId == plantId).OrderBy(sd => sd.Timestamp).ToListAsync(cancellationToken);
    }
}
