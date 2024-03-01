using static WeatherService;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorAppWASM.Services
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
                
        }
        public async Task<CountryData> GetCountryAsync(string country)
        {
            try
            {

                var apiURL = $"https://studies.cs.helsinki.fi/restcountries/api/name/{country}";
                return await _httpClient.GetFromJsonAsync<CountryData>(apiURL);
            }
            catch (Exception ex)
            {
                // Handle error
                Console.WriteLine($"Error fetching country data: {ex.Message}");
                return null;
            }
        }
        public class CountryData
        {
            public string[] capital { get; set; }
            public NameData name { get; set; }
            // Other properties representing weather data
        }

        public class NameData
        {
            public string common { get; set; }
        }
    }
}
