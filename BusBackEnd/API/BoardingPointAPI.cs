
public static class BoardingPointAPI
{
    public static WebApplication BoardingPointApi(this WebApplication app, string ConnectionString)
    {
        BoardingPointController controller = new BoardingPointController();
        app.MapGet("BoardingPointDetails", () => controller.GetBoardingPointDetails(ConnectionString));
        return app;
    }
}