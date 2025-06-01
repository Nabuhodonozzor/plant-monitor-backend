namespace PlantMonitorAPI.Requests.PlantRequests;

using AutoMapper;
using MediatR;
using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.Requests.Base;
using PlantMonitorAPI.Services.Interfaces;

public class CreatePlantCommand : IRequest
{
    public required string PlantName { get; set; }
}

public class CreatePlantCommandHandler(IPlantsService plantService, IMapper mapper) : RequestHandlerBase(mapper), IRequestHandler<CreatePlantCommand>
{
    private readonly IPlantsService plantService = plantService;

    public async Task Handle(CreatePlantCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var plant = new Plant
        {
            PlantName = command.PlantName
        };

        await plantService.AddEntity(plant, cancellationToken);
    }
}
