namespace Table;

public class BusTable
{
    public string BusName { get; set; }
    public string BusId { get; set; }
    public string BusType { get; set; }
    public int BusSeatCount { get; set; }
}

public class BusApiResponse
{
    public List<BusTable> Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}