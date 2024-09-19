namespace Table;

public class NewBookingDetailsTable
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