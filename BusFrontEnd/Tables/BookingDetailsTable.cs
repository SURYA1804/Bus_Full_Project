namespace Table;

public class BookingDetailsTable
{
    public string BusId { get; set; }
    public string BusName { get; set; }
    public string SeatId { get; set; }
    public string SeatType { get; set; }
    public int SeatPrice { get; set; }
    public string SeatPlace { get; set; }
    public int DiscountRate { get; set; }
    public DateTime date { get; set; }

}
public class BookedDetailsToBackEnd
{
    public int CustomerId { get; set; }
    public string BusId { get; set; }
    public string SeatId { get; set; }
    public int RouteId { get; set; }
    public int SeatPrice { get; set; }
    public int DiscountRate { get; set; }
    public DateTime Date { get; set; }
    public int BoardingPointId { get; set; }
    public int DropPointId { get; set; }
}
