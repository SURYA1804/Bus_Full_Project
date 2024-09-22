namespace Table;

public class DropPointTable
{
    public int DropPointId { get; set; }
    public int RouteId { get; set; }
    public string Point { get; set; }
}

public class DropPointAPIResponse
{
    public List<DropPointTable> Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}