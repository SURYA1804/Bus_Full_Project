namespace Table;
public class BookingRecordsTable
{
    public string BusName { get; set; }
    public string SeatType { get; set; }
    public string SeatPlace { get; set; }
    public int ActualSeatPrice { get; set; }
    public int FinalSeatPrice { get; set; }
    public int DiscountRate { get; set; }
    public string Route { get; set; }
    public DateTime DateTime { get; set; }
    public string BoardingPoint { get; set; }
    public string DropPoint { get; set; }

}
public class BookingRecordTablesApiResponse
{
    public List<BookingRecordsTable> Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}