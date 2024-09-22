namespace Table;
public class SeatTable
{
    public string BusId { get; set; }
    public string SeatId { get; set; }
    public string SeatType { get; set; }
    public int SeatPrice { get; set; }
    public string SeatPlace { get; set; }
}
public class SeatApiResponse
{
    public List<SeatTable> Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}