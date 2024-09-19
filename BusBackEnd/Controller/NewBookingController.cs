using Microsoft.AspNetCore.Mvc;
using Table;

[ApiController]
[Route("Book_Seats")]

public class NewBookingController : ControllerBase
{
    [HttpPost("Book_Seats")]

    public async Task<IActionResult> BookSeats([FromBody] List<NewBookingDetailsTable> BookedSeats, string ConnectionString)
    {
        var result = NewBookingDetails.SetNewBookingDetails(BookedSeats, ConnectionString);
        if (result == "true")
        {
            return Ok("Success");
        }
        else
        {
            return BadRequest(result);
        }
    }
}
