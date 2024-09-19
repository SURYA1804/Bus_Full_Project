using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;
using Table;

public static class BoardingPointDetails
{
    public static List<BoardingPointTable> GetBoardingPointDetails(string ConnectionString)
    {
        List<BoardingPointTable> BoardingPoints = new List<BoardingPointTable>();
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var context = new MyDbContext(optionsBuilder.Options))
        {
            BoardingPoints = context.BoardingPoint.ToList();
            return BoardingPoints;
        }
    }
}