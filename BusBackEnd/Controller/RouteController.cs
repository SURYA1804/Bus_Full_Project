using Microsoft.AspNetCore.Mvc;
using Table;
[ApiController]
[Route("RouteDetails")]

public class RouteController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRouteDetails(string ConnectionString)
    {
        var routes = RouteDetails.GetRouteDetails(ConnectionString);
        return Ok(routes);
    }
}
