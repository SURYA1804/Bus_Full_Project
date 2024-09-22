namespace Table;

public class RouteTable
{
    public int RouteId { get; set; }
    public string BusId { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
}

public class RouteTableApiResponse
{
    public List<RouteTable> Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}