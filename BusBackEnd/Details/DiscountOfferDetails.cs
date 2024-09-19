using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;


public static class DiscountDetails
{
    public static dynamic DiscountOffer(string ConnectionString)
    {

        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            dynamic list = (from discount in context.Discount
                            join bus in context.Bus on discount.BusId equals bus.BusId
                            select new
                            {
                                bus.BusName,
                                discount.SeatType,
                                discount.DiscountRate
                            }
            ).ToList();
            return list;
        }

    }


}