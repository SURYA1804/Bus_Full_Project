using Microsoft.AspNetCore.Mvc;
using Table;
[ApiController]
[Route("Customer")]
public class CustomerController : ControllerBase
{
    [HttpPost("Create_Customer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerTable customer, string ConnectionString)
    {
        var result = CustomerDetails.CreateCustomer(customer, ConnectionString);
        if (result == "true")
        {
            return Ok("Succes");
        }
        else
        {
            return BadRequest($"Error in Creating Account.ERROR[{result}]");
        }

    }
    [HttpPut("Update_Customer")]
    public async Task<IActionResult> UpdateCustomer([FromBody] CustomerTable customer, string ConnectionString)
    {
        var result = CustomerDetails.UpdateCustomer(customer, ConnectionString);
        if (result == "true")
        {
            return Ok("Succes");
        }
        else
        {
            return BadRequest($"Error in Creating Account.ERROR[{result}]");
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetCustomer(string email, string password, string ConnectionString)
    {
        CustomerTable customer = CustomerDetails.GetCustomer(email, password, ConnectionString);
        if (customer != null)
        {
            return Ok(customer);
        }
        else
        {
            return BadRequest("Not Found");
        }
    }
    [HttpGet]
    public async Task<IActionResult> CustomerBookingRecords(int Id, string ConnectionString)
    {
        return Ok(CustomerDetails.CustomerBookingRecords(Id, ConnectionString));
    }
}