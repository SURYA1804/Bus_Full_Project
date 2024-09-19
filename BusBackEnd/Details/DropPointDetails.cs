using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;
using Table;

public static class DropPointDetails
{
    public static List<DropPointTable> GetDropPointDetails(string ConnectionString)
    {
        List<DropPointTable> DropPoints = new List<DropPointTable>();
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            DropPoints = context.DropPoint.ToList();
            return DropPoints;
        }
    }
}