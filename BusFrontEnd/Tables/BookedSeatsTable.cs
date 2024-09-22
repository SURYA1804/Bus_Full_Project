namespace Table;
public class BookedSeatsTable
{
    public string BusId { get; set; }
    public string SeatId { get; set; }
    public int CustomerId { get; set; }
    public int RouteId { get; set; }
    public DateTime Slot { get; set; }

}

public class BookedSeatsTableAPIResponse
{
    public List<BookedSeatsTable> Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}