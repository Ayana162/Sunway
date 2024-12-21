using HotelAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<HotelDAL>();
var app = builder.Build();

app.MapControllers();

app.Run();
