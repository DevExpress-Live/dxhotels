using DxHotels.Blazor.Data;
using DxHotels.Blazor.Components;
using DxHotels.Blazor.Data.Models;
using Microsoft.EntityFrameworkCore;
using DxHotels.Blazor;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDevExpressBlazor(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});

const string connectionName = "HotelBookingConnectionString";
var connectionString = builder.Configuration.GetConnectionString(connectionName) ??
        throw new InvalidOperationException($"Connection {connectionName} is missing in config");
builder.Services.AddDbContext<HotelBookingContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();