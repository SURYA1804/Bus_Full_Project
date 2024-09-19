using Table;

public static class NewBookingAPI
{
    public static WebApplication NewBookingApi(this WebApplication app, string ConnectionString)
    {
        NewBookingController controller = new NewBookingController();
        app.MapPost("Book_Seats", (List<NewBookingDetailsTable> BookedSeats) => controller.BookSeats(BookedSeats, ConnectionString));
        return app;
    }
}