using System.Net;
using System.Text;
using Newtonsoft.Json;
using Table;
namespace Details;

public static class BookedSeatsDetails
{
    private static readonly HttpClient http = new HttpClient();

    public static List<BookedSeatsTable> BookedSeats = new List<BookedSeatsTable>();


    public static async Task SetBookedSeatsDetails()
    {
        string token = $"email:password:{CustomerDetails.customer.Id}";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        BookedSeatsTableAPIResponse BookedSeatsAPIRespose = new BookedSeatsTableAPIResponse();
        HttpResponseMessage response = await http.GetAsync($"{APIDetails.BaseAddress}/Booked_Seats");
        string jsonResponse = await response.Content.ReadAsStringAsync();
        BookedSeatsAPIRespose = JsonConvert.DeserializeObject<BookedSeatsTableAPIResponse>(jsonResponse);
        BookedSeats = BookedSeatsAPIRespose.Value;

    }
}