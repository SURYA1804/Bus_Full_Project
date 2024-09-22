namespace Table;
public class CustomerTable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MobileNo { get; set; }
    public string LoginPassword { get; set; }
    public DateOnly Date { get; set; }

}
public class CustomerApiResponse
{
    public CustomerTable Value { get; set; }
    public List<string> Formatters { get; set; }
    public List<string> ContentTypes { get; set; }
    public object DeclaredType { get; set; }
    public int StatusCode { get; set; }
}
