using MediatR;
using Microsoft.OpenApi.Models;

namespace Web.MinimalApis;

public static class MonitoringApi
{
    public static void MapHelloWorld(this WebApplication app)
    {
        app.MapGet("/private/HelloWorld", (IMediator mediator) => { return Task.FromResult("Hello World!"); })
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = "Endpoint de monitoring avec un 'Hello World'",
                Description = "Retourne un message de bienvenue",
                Tags = new List<OpenApiTag>{new() {Name = "Monitoring"}}
            });
    }
}