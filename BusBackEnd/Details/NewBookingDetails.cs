using Table;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;
using DotNet.Table;
using System.Linq;
using System.Runtime.CompilerServices;

public static class NewBookingDetails
{
    public static string SetNewBookingDetails(List<NewBookingDetailsTable> BookedSeats, string ConnectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        try
        {
            foreach (var record in BookedSeats)
            {
                using (var context = new MyDbContext(optionsBuilder.Options))
                {
                    int NewRecordId = context.BookingRecords.Any() ? context.BookingRecords.Max(e => e.RecordId) + 1 : 1;
                    int NewBookedId = context.Booked.Any() ? context.Booked.Max(e => e.BookedId) + 1 : 1;
                    context.Booked.Add(new BookedSeatsTable
                    {
                        BookedId = NewBookedId,
                        BusId = record.BusId,
                        SeatId = record.SeatId,
                        CustomerId = record.CustomerId,
                        Slot = record.Date.ToUniversalTime(),
                        RouteId = record.RouteId,
                        BoardingPointId = record.BoardingPointId,
                        DropPointId = record.DropPointId
                    });
                    context.BookingRecords.Add(new BookingRecordsTable
                    {
                        CustomerId = record.CustomerId,
                        BusId = record.BusId,
                        SeatId = record.SeatId,
                        Price = record.SeatPrice,
                        DiscountRate = record.DiscountRate,
                        DateTime = record.Date.ToUniversalTime(),
                        RecordId = NewRecordId,
                        RouteId = record.RouteId,
                        BoardingPointId = record.BoardingPointId,
                        DropPointId = record.DropPointId
                    });
                    context.SaveChanges();
                }
            }
            return "true";
        }
        catch (Exception ex)
        {
            return $"{ex}";
        }
    }
}