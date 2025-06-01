namespace PlantMonitorAPI.Requests.PlantRequests;

using System.Data.Entity;
using AutoMapper;
using MediatR;
using PlantMonitorAPI.Requests.Base;
using PlantMonitorAPI.Services.Interfaces;
using PlantMonitorAPI.ViewModels.Plants;

public class GetPlantsListModelCommand : IRequest<IEnumerable<PlantViewModel>> { }

public class GetPlantsListModelCommandHandler(IPlantsService plantService, IMapper mapper) : RequestHandlerBase(mapper), IRequestHandler<GetPlantsListModelCommand, IEnumerable<PlantViewModel>>
{
    private readonly IPlantsService plantsService = plantService;

    public async Task<IEnumerable<PlantViewModel>> Handle(GetPlantsListModelCommand request, CancellationToken cancellationToken)
    {
        var plants = await this.plantsService.GetEntitiesQuery().ToListAsync(cancellationToken);

        return this.Map<IEnumerable<PlantViewModel>>(plants);
    }
}
