using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;
using DotNet.Table;


public static class BusDetails
{

    public static List<BusTable> GetBus(string ConnectionString, string BusId)
    {
        List<BusTable> Bus = new List<BusTable>();
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            Bus = context.Bus.Where(b => b.BusId == BusId).ToList();
            return Bus;
        }
    }

}