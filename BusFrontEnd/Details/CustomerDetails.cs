using System.Net;
using System.Text;
using Newtonsoft.Json;
using Table;
namespace Details;
public static class CustomerDetails
{
    private static readonly HttpClient http = new HttpClient();

    public static CustomerTable customer = new CustomerTable();
    public static List<BookingRecordsTable> customer_booking_records = new List<BookingRecordsTable>();

    public static async Task CustomerDetailAsync(string email, string password)
    {
        CustomerApiResponse response1 = new CustomerApiResponse();
        HttpResponseMessage response = await http.GetAsync($"{APIDetails.BaseAddress}/Customer/{email}/{password}");
        string token = $"{email}:{password}:{customer.Id}";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        response1 = JsonConvert.DeserializeObject<CustomerApiResponse>(jsonResponse);
        customer = response1.Value;

    }

    public static async Task<bool> CreateCustomerAsync(CustomerTable customer)
    {
        var json = JsonConvert.SerializeObject(customer);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        string token = "create#new";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await http.PostAsync($"{APIDetails.BaseAddress}/Customer/Create_Customer", content);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        var ApiResponse = JsonConvert.DeserializeObject<APIResponse>(jsonResponse);
        return ApiResponse.StatusCode <= 201;

    }
    public static async Task<bool> UpdateCustomerDetailsAsync()
    {
        var json = JsonConvert.SerializeObject(customer);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        string token = $"email:password:{customer.Id}";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await http.PutAsync($"{APIDetails.BaseAddress}/Customer/Update_Customer", content);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        var ApiResponse = JsonConvert.DeserializeObject<APIResponse>(jsonResponse);
        return ApiResponse.StatusCode <= 200;

    }
    public static async Task CustomerBookingRecords()
    {
        string token = $"email:password:{customer.Id}";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        HttpResponseMessage response = await http.GetAsync($"{APIDetails.BaseAddress}/Customer/Booking_Records/{customer.Id}");
        response.EnsureSuccessStatusCode();
        string jsonResponse = await response.Content.ReadAsStringAsync();
        BookingRecordTablesApiResponse response1 = JsonConvert.DeserializeObject<BookingRecordTablesApiResponse>(jsonResponse);
        customer_booking_records = response1.Value;

    }
}
