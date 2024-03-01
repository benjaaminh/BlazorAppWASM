using Microsoft.JSInterop;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
public class WeatherService
{
    private readonly HttpClient _httpClient;
    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<WeatherData> GetWeatherAsync(string country)
    {

        try
        {
            

            var apiURL = $"https://api.openweathermap.org/data/2.5/weather?q={country}&units=metric&appid={apiKey}";
            Console.WriteLine($"API Key: {apiKey}");
            return await _httpClient.GetFromJsonAsync<WeatherData>(apiURL);
        }
        catch (Exception ex)
        {
            // Handle error
            Console.WriteLine($"Error fetching weather data: {ex.Message}");
            return null;
        }
    }
    public class WeatherData
    {
        public WeatherArray[] weather { get; set; }
        public MainData main { get; set; }
        // Other properties representing weather data
    }
    public class MainData
    {
        public double temp { get; set; }
    }

    public class WeatherArray
    {
        public string icon { get; set; }
    }
}
