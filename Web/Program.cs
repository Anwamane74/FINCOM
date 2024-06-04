using MediatR;
using Service.Features.Demonstration;
using Shared.Features.Demonstration;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddMediatR(typeof(GetWeatherForecastCommand).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetWeatherForecasts>());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/weatherforecast", async (IMediator mediator) =>
    {
        var forecasts = await mediator.Send(new GetWeatherForecastCommand());
        return forecasts;
    })
    .WithName("Demonstration")
    .WithTags("Demonstration")
    .WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}