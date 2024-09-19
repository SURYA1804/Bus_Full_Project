using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("DropPointDetails")]

public class DropPointController : ControllerBase
{
    public IActionResult GetDropPointDetails(string ConnectionString)
    {
        var DropPoints = DropPointDetails.GetDropPointDetails(ConnectionString);
        return Ok(DropPoints);
    }
}