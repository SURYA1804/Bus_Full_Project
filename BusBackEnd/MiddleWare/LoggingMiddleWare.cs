using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
public class LoggingMiddleware
{
    private readonly RequestDelegate next;

    public LoggingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
        await next(context);
        stopwatch.Stop();
        Console.WriteLine($"Response: {context.Response.StatusCode} - Time Taken: {stopwatch.ElapsedMilliseconds} ms");
    }
}