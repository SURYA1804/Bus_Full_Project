using Newtonsoft.Json;
using Table;
namespace Details;
public static class SeatDetails
{
    private static readonly HttpClient http = new HttpClient();
    public static List<SeatTable> Seats = new List<SeatTable>();
    public static async Task GetSeats(string BusId)
    {

        SeatApiResponse SeatResponse = new SeatApiResponse();
        HttpResponseMessage ApiResponse = await http.GetAsync($"{APIDetails.BaseAddress}/BusDetails/{BusId}");
        string jsonResponse = await ApiResponse.Content.ReadAsStringAsync();
        SeatResponse = JsonConvert.DeserializeObject<SeatApiResponse>(jsonResponse);
        Seats = SeatResponse.Value;
    }
}