namespace VitoshaRouter.Domain.Models;

public record WeatherData(
    double PrecipitationMmPerHour,
    double WindSpeedMetersPerSec,
    double TemperatureCelsius,
    bool IsFromFallbackCache,
    string SourceWarning = "");
