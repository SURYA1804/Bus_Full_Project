using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;
using DotNet.Table;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.InteropServices.Marshalling;
namespace DotNet.Table;

public static class SeatDetails
{
    public static List<SeatTable> seats = new List<SeatTable>();
    public static List<SeatTable> GetSeats(string BusId, string ConnectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);

        using (var context = new MyDbContext(optionsBuilder.Options))
        {

            seats = context.Seat.Where(s => s.BusId == BusId).ToList();
            return seats;
        }

    }
}