namespace PlantMonitorAPI.API;

using Microsoft.AspNetCore.Mvc;
using PlantMonitorAPI.API.Base;
using PlantMonitorAPI.Requests.SensorDataRequests;
using PlantMonitorAPI.ViewModels.SensorData;

public class SensorDataController : MyControllerBase
{
    private const string RouteBase = "/api/sensorData";

    [HttpPost(RouteBase)]
    public async Task<ActionResult<int>> CreateSensorDataRecord([FromBody] CreateSensorDataRecordCommand command)
    {
        return await this.Send(command);
    }

    [HttpGet(RouteBase)]
    public async Task<ActionResult<Dictionary<int, IEnumerable<SensorDataViewModel>>>> GetSensorDataRecords([FromQuery] GetSensorDataQuery query)
    {
        return await this.Send(query);
    }
}
