using Table;
using DotNet.Dbcontext;
using DotNet.Table;
using Microsoft.EntityFrameworkCore;
public static class RouteDetails
{
    public static List<RouteTable> GetRouteDetails(string ConnectionString)
    {
        List<RouteTable> routes = new List<RouteTable>();
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            routes = context.Route.ToList();
            return routes;
        }
    }
}