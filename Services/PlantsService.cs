namespace PlantMonitorAPI.Services;

using PlantMonitorAPI.Database;
using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.Services.Base;
using PlantMonitorAPI.Services.Interfaces;

public class PlantsService(PlantMonitorDBContext ctx) : ServiceBase<Plant>(ctx), IPlantsService
{
}
