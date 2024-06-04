using MediatR;
using Shared.Features.Demonstration;

namespace Service.Features.Demonstration;

public class GetWeatherForecasts : IRequestHandler<GetWeatherForecastCommand, WeatherForecastDtoList>
{
    public Task<WeatherForecastDtoList> Handle(GetWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();

        return Task.FromResult(new WeatherForecastDtoList
        {
            WeatherForecasts = forecasts.ToList()
        });
    }
}