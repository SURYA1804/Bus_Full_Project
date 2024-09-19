using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;
using Table;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using DotNet.Table;

public static class BookedSeatsDetails
{
    public static List<BookedSeatsTable> GetBookedSeats(string ConnectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            List<BookedSeatsTable> BookedSeats = context.Booked.ToList();
            return BookedSeats;

        }
    }
}