using DotNet.API;
using DotNet.Dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<MyDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Bus")));
var app = builder.Build();

string ConnectionString = "host='127.0.0.1';database='postgres';user Id='postgres';password='Alterego@2';port = 5432;";

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<AuthenticationMiddleWare>(ConnectionString);

app.CustomerApi(ConnectionString);
app.DiscountOfferApi(ConnectionString);
app.BookedSeatsApi(ConnectionString);
app.BusApi(ConnectionString);
app.SeatApi(ConnectionString);
app.NewBookingApi(ConnectionString);
app.RouteApi(ConnectionString);
app.BoardingPointApi(ConnectionString);
app.DropPointApi(ConnectionString);

app.Run();



