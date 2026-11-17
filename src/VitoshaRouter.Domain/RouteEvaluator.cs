using System;

namespace VitoshaRouter.Domain
{
    public static class RouteEvaluator
    {
        public static double CalculateHaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371000;
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double ToRadians(double angle) => angle * Math.PI / 180.0;

        public static double CalculateToblerSpeed(double slope)
        {
            return 6.0 * Math.Exp(-3.5 * Math.Abs(slope + 0.05));
        }

        public static double CalculateMeteoCoefficient(double precipitation, double windSpeed, double temperature, bool isAbove1800m)
        {
            double iceFactor = (temperature <= 0 && precipitation > 0) ? 1.0 : 0.0;
            double windMultiplier = isAbove1800m ? 0.06 : 0.03;

            return 1.0 + (0.04 * precipitation) + (windMultiplier * Math.Max(0, windSpeed - 8.0)) + (0.20 * iceFactor);
        }

        public static (double timeMinutes, double difficulty, double effort) EvaluateEdge(
            double lengthMeters, double elevationChangeMeters, double baseDifficulty, double terrainCoefficient, double meteoCoefficient)
        {
            double lengthKm = lengthMeters / 1000.0;
            double slope = lengthMeters > 0 ? elevationChangeMeters / lengthMeters : 0.0;

            double v0 = CalculateToblerSpeed(slope);
            double baseTimeMinutes = v0 > 0 ? (lengthKm / v0) * 60.0 : 0.0;

            double finalTime = baseTimeMinutes * terrainCoefficient * meteoCoefficient;

            double rawDifficulty = baseDifficulty + (12.0 * Math.Abs(slope)) + (2.0 * (terrainCoefficient - 1.0)) + (2.5 * (meteoCoefficient - 1.0));
            double finalDifficulty = Math.Clamp(rawDifficulty, 1.0, 10.0);

            double effort = finalTime * (1.0 + 0.2 * finalDifficulty);

            return (finalTime, finalDifficulty, effort);
        }
    }
}
