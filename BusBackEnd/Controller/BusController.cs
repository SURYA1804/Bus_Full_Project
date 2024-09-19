using Microsoft.AspNetCore.Mvc;
using Table;
[ApiController]
[Route("BusDetails")]

public class BusController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBus(string ConnectionString, string BusId)
    {
        var Buses = BusDetails.GetBus(ConnectionString, BusId);
        return Ok(Buses);

    }

}