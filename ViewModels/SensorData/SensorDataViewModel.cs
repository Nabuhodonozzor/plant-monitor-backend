namespace PlantMonitorAPI.ViewModels.SensorData;

public class SensorDataViewModel
{
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

    /// <summary>
    /// FK - Roślina, której dotyczy log
    /// </summary>
    public int PlantId { get; set; }
}
