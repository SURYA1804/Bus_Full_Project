using System.Net;
using System.Text;
using Newtonsoft.Json;
using Table;
namespace Details;

public static class DiscountDetails
{
    public static List<DiscountOfferTable> DiscountOffer = new List<DiscountOfferTable>();
    private static readonly HttpClient http = new HttpClient();
    public static async Task SetDiscountDetails()
    {
        DiscountOfferTableApiResponse DiscountOfferApiResponse = new DiscountOfferTableApiResponse();
        HttpResponseMessage respone = await http.GetAsync($"{APIDetails.BaseAddress}/Discount_Offer");
        string jsonResponse = await respone.Content.ReadAsStringAsync();
        DiscountOfferApiResponse = JsonConvert.DeserializeObject<DiscountOfferTableApiResponse>(jsonResponse);
        DiscountOffer = DiscountOfferApiResponse.Value;
    }
}