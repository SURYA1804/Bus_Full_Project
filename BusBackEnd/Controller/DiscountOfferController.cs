using Microsoft.AspNetCore.Mvc;
using Table;

[ApiController]
[Route("Discount_Offer")]
public class DiscountOfferController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDiscountOfferDetails(string configuration)
    {
        var discountOffer = DiscountDetails.DiscountOffer(configuration);
        return Ok(discountOffer);
    }
}