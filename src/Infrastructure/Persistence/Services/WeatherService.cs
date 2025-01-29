
using Application.Services;

namespace Infrastructure.Persistence.Services
{
    internal sealed class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetWeatherAsync()
        {
            var response = await _httpClient.GetAsync("https://air-quality-api.open-meteo.com/v1/air-quality?latitude=23&longitude=-102&hourly=pm10,pm2_5&timezone=auto&past_days=1");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}