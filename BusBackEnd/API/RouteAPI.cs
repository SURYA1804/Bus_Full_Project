using System.Diagnostics.Contracts;

public static class RouteAPI
{
    public static WebApplication RouteApi(this WebApplication app, string ConnectionString)
    {
        RouteController controller = new RouteController();
        app.MapGet("RouteDetails", () => controller.GetRouteDetails(ConnectionString));
        return app;
    }
}