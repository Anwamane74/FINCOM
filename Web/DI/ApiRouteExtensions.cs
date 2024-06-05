namespace Web.DI;

public static class ApiRouteExtensions
{
    public static WebApplication MapApiRoutes(this WebApplication app)
    {
        var methods = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.Name.EndsWith("Api", StringComparison.InvariantCultureIgnoreCase))
            .SelectMany(x => x.GetMethods())
            .Where(x => x.Name.StartsWith("Map", StringComparison.InvariantCultureIgnoreCase) &&
                        x.GetParameters()[0].ParameterType == typeof(WebApplication));

        foreach (var method in methods) method.Invoke(null, new object[] { app });

        return app;
    }
}