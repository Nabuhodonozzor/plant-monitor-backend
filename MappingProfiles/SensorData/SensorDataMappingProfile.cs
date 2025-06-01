namespace PlantMonitorAPI.MappingProfiles.SensorData;

using AutoMapper;
using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.ViewModels.SensorData;

public class SensorDataMappingProfile : Profile
{
    public SensorDataMappingProfile()
    {
        CreateMap<SensorData, SensorDataViewModel>();
    }
}
