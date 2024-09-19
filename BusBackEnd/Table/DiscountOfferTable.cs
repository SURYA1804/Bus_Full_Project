using System.ComponentModel.DataAnnotations.Schema;
namespace Table;

[Table("Discount")]
public class DiscountOfferTable
{
    [Column("BusId")]
    public string BusId { get; set; }

    [Column("SeatType")]
    public string SeatType { get; set; }

    [Column("DiscountRate")]
    public int DiscountRate { get; set; }
}
