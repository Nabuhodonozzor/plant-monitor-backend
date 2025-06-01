using System.Threading.Tasks;
using PlantMonitorAPI.Database;
using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.Services.Base;
using PlantMonitorAPI.Services.Interfaces;

namespace PlantMonitorAPI.Services;

public class PlantsService(PlantMonitorDBContext ctx) : ServiceBase<Plant>(ctx), IPlantsService
{
    public async Task AddPlant(Plant plant, CancellationToken cancellationToken)
    {
        this.Entities.Add(plant);
        await this.SaveChangesAsync(cancellationToken);
    }
}
