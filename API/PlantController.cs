namespace PlantMonitorAPI.API;

using Microsoft.AspNetCore.Mvc;
using PlantMonitorAPI.API.Base;
using PlantMonitorAPI.Requests.PlantRequests;
using PlantMonitorAPI.ViewModels.Plants;

public class PlantController : MyControllerBase
{
    private const string RouteBase = "/api/plants";

    [HttpGet(RouteBase)]
    public async Task<ActionResult<IEnumerable<PlantViewModel>>> GetPlants([FromQuery] GetPlantsListModelCommand command)
    {
        return await this.Send(command);
    }

    [HttpPost(RouteBase)]
    public async Task<ActionResult> CreatePlant([FromBody] CreatePlantCommand command)
    {
        return await this.Send(command);
    }
}
