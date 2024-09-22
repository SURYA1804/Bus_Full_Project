public class APIResponse
{
    public dynamic Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}