using Table;
public static class CustomerAPI
{
    public static WebApplication CustomerApi(this WebApplication app, string ConnectionString)
    {
        CustomerController controller = new CustomerController();
        app.MapGet("Customer/{email}/{LoginPassword}", (string email, string LoginPassword) => controller.GetCustomer(email, LoginPassword, ConnectionString));

        app.MapPost("Customer/Create_Customer", (CustomerTable customer) => controller.CreateCustomer(customer, ConnectionString));

        app.MapPut("Customer/Update_Customer", (CustomerTable customer) => controller.UpdateCustomer(customer, ConnectionString));

        app.MapGet("Customer/Booking_Records/{Id}", (int Id) => controller.CustomerBookingRecords(Id, ConnectionString));
        return app;
    }


}