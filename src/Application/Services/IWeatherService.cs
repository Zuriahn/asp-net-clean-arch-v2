
namespace Application.Services
{
    public interface IWeatherService
    {
        Task<string> GetWeatherAsync();
    }
}