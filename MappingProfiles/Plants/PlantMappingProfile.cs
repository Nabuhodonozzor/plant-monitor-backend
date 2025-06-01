namespace PlantMonitorAPI.MappingProfiles.Plants;

using AutoMapper;
using PlantMonitorAPI.Database.Entities;
using PlantMonitorAPI.ViewModels.Plants;

public class PlantMappingProfile : Profile
{
    public PlantMappingProfile()
    {
        CreateMap<Plant, PlantViewModel>();
    }
}
