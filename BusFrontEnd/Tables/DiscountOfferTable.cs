namespace Table;


public class DiscountOfferTable
{

    public string BusName { get; set; }
    public string SeatType { get; set; }
    public int DiscountRate { get; set; }

}

public class DiscountOfferTableApiResponse
{
    public List<DiscountOfferTable> Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}