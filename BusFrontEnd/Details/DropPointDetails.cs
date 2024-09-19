using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Table;
namespace Details;

public static class DropPointDetails
{
    public static List<DropPointTable> DropPoints = new List<DropPointTable>();
    public static readonly HttpClient http = new HttpClient();
    public static async Task GetDropPointDetails()
    {
        DropPointAPIResponse DropPointApiResponse = new DropPointAPIResponse();
        HttpResponseMessage response = await http.GetAsync($"{APIDetails.BaseAddress}/DropPoint_Details");
        string jsonResponse = await response.Content.ReadAsStringAsync();
        DropPointApiResponse = JsonConvert.DeserializeObject<DropPointAPIResponse>(jsonResponse);
        DropPoints = DropPointApiResponse.Value;
    }
}