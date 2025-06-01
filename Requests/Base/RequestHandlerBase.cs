using AutoMapper;

namespace PlantMonitorAPI.Requests.Base;

public class RequestHandlerBase(IMapper mapper)
{
    private readonly IMapper mapper = mapper;

    protected TDestination Map<TDestination>(object source)
    {
        return this.mapper.Map<TDestination>(source);
    }
}
