
public static class DropPointAPI
{
    public static WebApplication DropPointApi(this WebApplication app, string ConnectionString)
    {
        DropPointController controller = new DropPointController();
        app.MapGet("DropPoint_Details", () => controller.GetDropPointDetails(ConnectionString));
        return app;
    }
}