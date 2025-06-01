using System.Data.Entity;
using AutoMapper;
using MediatR;
using PlantMonitorAPI.Requests.Base;
using PlantMonitorAPI.Services.Interfaces;
using PlantMonitorAPI.ViewModels.SensorData;

namespace PlantMonitorAPI.Requests.SensorDataRequests;

public class GetSensorDataQuery : IRequest<Dictionary<int, IEnumerable<SensorDataViewModel>>>
{
}

public class GetSensorDataQueryHandler(ISensorDataService sensorDataService, IMapper mapper) : RequestHandlerBase(mapper), IRequestHandler<GetSensorDataQuery, Dictionary<int, IEnumerable<SensorDataViewModel>>>
{
    private readonly ISensorDataService sensorDataService = sensorDataService;


    public async Task<Dictionary<int, IEnumerable<SensorDataViewModel>>> Handle(GetSensorDataQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var sensorData = await this.sensorDataService.GetEntitiesQuery().OrderBy(sd => sd.Timestamp).ToListAsync(cancellationToken);

        return sensorData
            .GroupBy(sd => sd.PlantId)
            .ToDictionary(
                keySelector: group => group.Key,
                elementSelector: group => this.Map<IEnumerable<SensorDataViewModel>>(group.ToList())
            );
    }
}

