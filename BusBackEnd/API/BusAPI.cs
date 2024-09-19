

public static class BusAPI
{
    public static WebApplication BusApi(this WebApplication app, string ConnectionString)
    {
        BusController controller = new BusController();
        app.MapGet("Bus/{BusId}", (string BusId) => controller.GetBus(ConnectionString, BusId));
        return app;
    }

}