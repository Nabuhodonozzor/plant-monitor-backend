using System.ComponentModel.DataAnnotations;
using PlantMonitorAPI.Database.Entities.Base;

namespace PlantMonitorAPI.Database.Entities;

public class Plant : EntityBase
{
    [Required]
    [MaxLength(100)]
    public required string PlantName { get; set; }

    /// <summary>
    /// Dane z sensorów odpowiadające roślinie
    /// </summary>
    public ICollection<SensorData> SensorDataRecords { get; set; } = new List<SensorData>();
}
