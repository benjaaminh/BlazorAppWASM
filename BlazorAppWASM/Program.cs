using BlazorAppWASM;
using BlazorAppWASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.Configuration.AddJsonFile("appsettings.json");
//var apiKey = builder.Configuration["Weather:apiKey"];
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<WeatherService>(); //add weather service to project
builder.Services.AddScoped<CountryService>();
await builder.Build().RunAsync();
