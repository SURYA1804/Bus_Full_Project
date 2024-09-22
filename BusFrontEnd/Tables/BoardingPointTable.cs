namespace Table;

public class BoardingPointTable
{
    public int BoardingPointId { get; set; }
    public int RouteId { get; set; }
    public string Point { get; set; }

}

public class BoardingPointAPIResponse
{
    public List<BoardingPointTable> Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}