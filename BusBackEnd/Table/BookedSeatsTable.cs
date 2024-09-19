namespace DotNet.Table;

public class BookedSeatsTable
{
    public int BookedId { get; set; }
    public string BusId { get; set; }
    public string SeatId { get; set; }
    public int CustomerId { get; set; }
    public int RouteId { get; set; }
    public DateTime Slot { get; set; }
    public int BoardingPointId { get; set; }
    public int DropPointId { get; set; }


}