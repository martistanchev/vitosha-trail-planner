using VitoshaRouter.Domain.Models;

namespace VitoshaRouter.Application.Interfaces;

public interface IWeatherService
{
    Task<WeatherData> GetCurrentWeatherAsync(double latitude, double longitude, double elevationMeters, CancellationToken ct = default);
}
