using System.Net;
using Microsoft.EntityFrameworkCore;
using DotNet.Dbcontext;
using System.Data.Common;
public class AuthenticationMiddleWare
{
    private readonly RequestDelegate next;
    private readonly string ConnectionString;

    public AuthenticationMiddleWare(RequestDelegate next, string ConnectionString)
    {
        this.next = next;
        this.ConnectionString = ConnectionString;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Authorization header missing.");
            Console.WriteLine("Authorization header missing.");
            return;
        }
        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        if (token == "create#new")
        {
            await next(context);
        }
        var details = token.Split(":");
        string email = details[0];
        string password = details[1];
        int id = int.Parse(details[2]);
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);
        using (var dbcontext = new MyDbContext(optionsBuilder.Options))
        {
            if (id != 0)
            {
                if (dbcontext.Customer.Any(c => c.Id == id))
                {
                    await next(context);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Invalid token.");
                    Console.WriteLine("Unauthorized");
                    return;
                }
            }
            else if (dbcontext.Customer.Any(c => c.Email == email && c.LoginPassword == password))
            {
                await next(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid token.");
                Console.WriteLine("Unauthorized");
                return;
            }

        }
    }
}