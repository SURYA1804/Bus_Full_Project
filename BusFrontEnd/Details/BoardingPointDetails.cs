using Newtonsoft.Json;
using Table;
namespace Details;

public static class BoardingDetails
{
    public static List<BoardingPointTable> BoardingPoints = new List<BoardingPointTable>();
    private static readonly HttpClient http = new HttpClient();

    public static async Task GetBoardingPoints()
    {
        BoardingPointAPIResponse BoardingPointApiResponse = new BoardingPointAPIResponse();
        string token = $"email:password:{CustomerDetails.customer.Id}";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await http.GetAsync($"{APIDetails.BaseAddress}/BoardingPointDetails");
        string jsonResponse = await response.Content.ReadAsStringAsync();
        BoardingPointApiResponse = JsonConvert.DeserializeObject<BoardingPointAPIResponse>(jsonResponse);
        BoardingPoints = BoardingPointApiResponse.Value;
    }
}