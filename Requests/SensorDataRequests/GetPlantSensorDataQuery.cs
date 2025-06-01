using AutoMapper;
using MediatR;
using PlantMonitorAPI.Requests.Base;
using PlantMonitorAPI.Services.Interfaces;
using PlantMonitorAPI.ViewModels.SensorData;

namespace PlantMonitorAPI.Requests.SensorDataRequests;

public class GetPlantSensorDataQuery : IRequest<IEnumerable<SensorDataViewModel>>
{
    public required int PlantId { get; set; }
}

public class GetPlantSensorDataQueryHandler(ISensorDataService sensorDataService, IMapper mapper) : RequestHandlerBase(mapper), IRequestHandler<GetPlantSensorDataQuery, IEnumerable<SensorDataViewModel>>
{
    private readonly ISensorDataService sensorDataService = sensorDataService;

    public async Task<IEnumerable<SensorDataViewModel>> Handle(GetPlantSensorDataQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var sensorData = await this.sensorDataService.GetPlantSensorData(request.PlantId, cancellationToken);

        return this.Map<IEnumerable<SensorDataViewModel>>(sensorData);
    }
}
