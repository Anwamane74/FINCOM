namespace Shared.Features.Demonstration;

public class WeatherForecastDtoList
{
    public List<WeatherForecastDto> WeatherForecasts { get; set; } = [];
}

public class WeatherForecastDto
{
    public WeatherForecastDto(DateOnly date, int temperatureC, string summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string Summary { get; set; }
}