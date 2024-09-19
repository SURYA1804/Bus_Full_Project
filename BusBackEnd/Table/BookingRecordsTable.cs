namespace DotNet.Table;

public class BookingRecordsTable
{
    public string BusId { get; set; }
    public string SeatId { get; set; }
    public int Price { get; set; }
    public int DiscountRate { get; set; }
    public int RecordId { get; set; }
    public int CustomerId { get; set; }
    public int RouteId { get; set; }
    public DateTime DateTime { get; set; }
    public int BoardingPointId { get; set; }
    public int DropPointId { get; set; }

}