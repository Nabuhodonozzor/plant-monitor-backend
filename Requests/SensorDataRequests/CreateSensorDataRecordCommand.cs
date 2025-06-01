namespace PlantMonitorAPI.Requests.SensorDataRequests;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.Requests.Base;
using PlantMonitorAPI.Services.Interfaces;

public class CreateSensorDataRecordCommand : IRequest<int>
{
    public required int PlantId { get; set; }

    /// <summary>
    /// Temperatura w C
    /// </summary>
    public required decimal Temperature { get; set; }

    /// <summary>
    /// Wilgotność powietrza w % (chyba)
    /// </summary>
    public required decimal AirHumidity { get; set; }

    /// <summary>
    /// Wilgotność gleby (ale nie wiem w czym)
    /// </summary>
    public required decimal SoilHumidity { get; set; }

    /// <summary>
    /// Czas pomiaru
    /// </summary>
    public required DateTime Timestamp { get; set; }
}

public class CreateSensorDataRecordCommandHandler(ISensorDataService sensorDataService, IMapper mapper) : RequestHandlerBase(mapper), IRequestHandler<CreateSensorDataRecordCommand, int>
{
    private readonly ISensorDataService sensorDataService = sensorDataService;

    public Task<int> Handle(CreateSensorDataRecordCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var sensorDataRecord = new SensorData
        {
            PlantId = request.PlantId,
            Temperature = request.Temperature,
            AirHumidity = request.AirHumidity,
            SoilHumidity = request.SoilHumidity,
            Timestamp = request.Timestamp
        };

        return this.sensorDataService.AddEntity(sensorDataRecord, cancellationToken);
    }
}
