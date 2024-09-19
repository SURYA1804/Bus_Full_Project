namespace DotNet.API;

public static class DiscountOfferAPI
{
    public static WebApplication DiscountOfferApi(this WebApplication app, string ConnectionString)
    {
        DiscountOfferController controller = new DiscountOfferController();
        app.MapGet("Discount_Offer", () => controller.GetDiscountOfferDetails(ConnectionString));
        return app;
    }
}