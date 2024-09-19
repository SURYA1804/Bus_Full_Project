using System.Net;
using System.Text;
using Newtonsoft.Json;
using Table;
namespace Details;

public static class BusDetails
{
    private static readonly HttpClient http = new HttpClient();
    public static List<BusTable> Buses = new List<BusTable>();
    public static async Task GetBusDetails(string BusId)
    {
        BusApiResponse BusResponse = new BusApiResponse();
        HttpResponseMessage ApiResponse = await http.GetAsync($"{APIDetails.BaseAddress}/Bus/{BusId}");
        string jsonResponse = await ApiResponse.Content.ReadAsStringAsync();
        BusResponse = JsonConvert.DeserializeObject<BusApiResponse>(jsonResponse);
        Buses = BusResponse.Value;
    }
}