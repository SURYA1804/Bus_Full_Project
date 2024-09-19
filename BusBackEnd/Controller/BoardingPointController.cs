using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("BoardingPointDetails")]

public class BoardingPointController : ControllerBase
{
    public IActionResult GetBoardingPointDetails(string ConnectionString)
    {
        var BoardingPoints = BoardingPointDetails.GetBoardingPointDetails(ConnectionString);
        return Ok(BoardingPoints);
    }
}