using Service.Features.Demonstration;
using Web.DI;

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

app.MapApiRoutes();

app.Run();