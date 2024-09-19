

public static class BookedSeatsAPI
{
    public static WebApplication BookedSeatsApi(this WebApplication app, string ConnectionString)
    {
        BookedSeatsController controller = new BookedSeatsController();
        app.MapGet("Booked_Seats", () => controller.GetBookedSeatDetails(ConnectionString));
        return app;
    }
}