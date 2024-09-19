using System.ComponentModel.DataAnnotations.Schema;

namespace Table;
[Table("Customers")]
public class CustomerTable
{
    [Column("CustomerId")]
    public int Id { get; set; }
    [Column("CustomerName")]
    public string Name { get; set; }
    [Column("CustomerEmail")]
    public string Email { get; set; }
    [Column("CustomerMobileNo")]
    public string MobileNo { get; set; }
    [Column("LoginPassword")]
    public string LoginPassword { get; set; }
    [Column("DateJoined")]
    public DateOnly Date { get; set; }

}