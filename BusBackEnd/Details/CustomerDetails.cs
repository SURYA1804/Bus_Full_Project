using Table;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;
using DotNet.Table;
using System.Linq;

public static class CustomerDetails
{

    public static string CreateCustomer(CustomerTable customer, string ConnectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);

        DateOnly date = new DateOnly();
        date = DateOnly.FromDateTime(DateTime.Today);
        CustomerTable Newcustomer = new CustomerTable();
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            Newcustomer.Id = context.Customer.Max(e => e.Id) + 1;
            bool isDuplicate = context.Customer.Any(c => c.Email == customer.Email);
            if (isDuplicate)
            {
                return "false";
            }
            Newcustomer.Name = customer.Name;
            Newcustomer.Email = customer.Email;
            Newcustomer.MobileNo = customer.MobileNo;
            Newcustomer.LoginPassword = customer.LoginPassword;
            Newcustomer.Date = date;
            try
            {
                context.Customer.Add(Newcustomer);
                context.SaveChanges();
                return "true";
            }
            catch (Exception e)
            {
                return $"{e}";
            }
        }
    }

    public static CustomerTable GetCustomer(string email, string LoginPassword, string ConnectionString)
    {
        CustomerTable customer = new CustomerTable();
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            customer = context.Customer.Where(c => c.Email == email && c.LoginPassword == LoginPassword).FirstOrDefault();

            return customer;

        }

    }
    public static string UpdateCustomer(CustomerTable customer, string ConnectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            try
            {
                var ExistingCustomer = context.Customer.Find(customer.Id);
                if (ExistingCustomer == null)
                {
                    return "Customer not found.";
                }
                ExistingCustomer.Name = customer.Name;
                ExistingCustomer.Email = customer.Email;
                ExistingCustomer.MobileNo = customer.MobileNo;
                ExistingCustomer.LoginPassword = customer.LoginPassword;
                context.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
    public static dynamic CustomerBookingRecords(int Id, string ConnectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {

            dynamic BookingRecords = (from records in context.BookingRecords
                                      join r in context.Route on records.RouteId equals r.RouteId
                                      join seat in context.Seat on new { records.SeatId, records.BusId } equals new { seat.SeatId, seat.BusId }
                                      join bus in context.Bus on records.BusId equals bus.BusId
                                      join board in context.BoardingPoint on records.BoardingPointId equals board.BoardingPointId
                                      join drop in context.DropPoint on records.DropPointId equals drop.DropPointId
                                      where records.CustomerId == Id
                                      select new
                                      {
                                          BusName = bus.BusName,
                                          SeatType = seat.SeatType,
                                          SeatPlace = seat.SeatPlace,
                                          ActualSeatPrice = seat.SeatPrice,
                                          FinalSeatPrice = records.Price,
                                          DiscountRate = records.DiscountRate,
                                          DateTime = records.DateTime,
                                          Route = $"{r.Start}-{r.End}",
                                          BoardingPoint = board.Point,
                                          DropPoint = drop.Point
                                      }).ToList();

            return BookingRecords;

        }

    }
}
