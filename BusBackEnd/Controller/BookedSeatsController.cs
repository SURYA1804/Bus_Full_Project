using Microsoft.AspNetCore.Mvc;
using Table;
[ApiController]
[Route("BookedSeats")]

public class BookedSeatsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBookedSeatDetails(string ConnectionString)
    {
        var BookedSeats = BookedSeatsDetails.GetBookedSeats(ConnectionString);
        return Ok(BookedSeats);

    }
}