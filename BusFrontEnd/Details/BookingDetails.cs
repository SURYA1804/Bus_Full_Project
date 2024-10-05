using System.Net;
using System.Text;
using Newtonsoft.Json;
using Table;
namespace Details;

public static class BookingDetails
{
    public static string BusId;
    public static string BusName;
    public static RouteTable Route;
    public static DateTime SelectedDate;
    public static BoardingPointTable BoardingPoint;
    public static DropPointTable DropPoint;
    private static readonly HttpClient http = new HttpClient();
    public static List<BookingDetailsTable> BookingSeats = new List<BookingDetailsTable>();
    public static async Task<bool> SendBookingDetails()
    {
        List<BookedDetailsToBackEnd> BookedDetails = new List<BookedDetailsToBackEnd>();
        foreach (var record in BookingDetails.BookingSeats)
        {
            BookedDetails.Add(new BookedDetailsToBackEnd
            {
                CustomerId = CustomerDetails.customer.Id,
                BusId = record.BusId,
                SeatId = record.SeatId,
                SeatPrice = record.SeatPrice,
                DiscountRate = record.DiscountRate,
                Date = SelectedDate,
                RouteId = Route.RouteId,
                BoardingPointId = BoardingPoint.BoardingPointId,
                DropPointId = DropPoint.DropPointId
            });
        }
        var json = JsonConvert.SerializeObject(BookedDetails);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        string token = $"email:password:{CustomerDetails.customer.Id}";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await http.PostAsync($"{APIDetails.BaseAddress}/Book_Seats", content);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        APIResponse ApiResponse = JsonConvert.DeserializeObject<APIResponse>(jsonResponse);
        return ApiResponse.StatusCode <= 200;
    }
}