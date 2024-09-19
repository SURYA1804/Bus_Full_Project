
public static class SeatAPI
{
    public static WebApplication SeatApi(this WebApplication app, string ConnectionString)
    {

        SeatController controller = new SeatController();
        app.MapGet("BusDetails/{BusId}", (string BusId) => controller.GetSeat(BusId, ConnectionString));
        return app;
    }

}