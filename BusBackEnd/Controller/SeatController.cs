using DotNet.Table;
using Microsoft.AspNetCore.Mvc;
using Table;
[ApiController]
[Route("BusDetails")]

public class SeatController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSeat(string BusId, string ConnectionString)
    {
        var Seats = SeatDetails.GetSeats(BusId, ConnectionString);
        return Ok(Seats);

    }
}