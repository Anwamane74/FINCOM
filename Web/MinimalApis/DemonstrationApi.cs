using MediatR;
using Shared.Features.Demonstration;

namespace Web.MinimalApis;

public static class DemonstrationApi
{
    public static void MapDemonstrationApi(this WebApplication app)
    {
        app.MapGet("/weatherforecast", async (IMediator mediator) =>
            {
                var forecasts = await mediator.Send(new GetWeatherForecastCommand());
                return forecasts;
            })
            .WithName("Demonstration")
            .WithTags("Demonstration")
            .WithOpenApi();
    }
}