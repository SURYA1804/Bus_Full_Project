using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Table;
namespace Details;

public static class RouteDetails
{
    public static List<RouteTable> Routes = new List<RouteTable>();
    private static readonly HttpClient http = new HttpClient();
    public static async Task GetRouteDetails()
    {
        RouteTableApiResponse routeTableApiResponse = new RouteTableApiResponse();
        string token = $"email:password:{CustomerDetails.customer.Id}";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await http.GetAsync($"{APIDetails.BaseAddress}/RouteDetails");
        string jsonResponse = await response.Content.ReadAsStringAsync();
        routeTableApiResponse = JsonConvert.DeserializeObject<RouteTableApiResponse>(jsonResponse);
        Routes = routeTableApiResponse.Value;
    }

}