using System;

namespace ShyneeBackend.Domain.Entities
{
    public class ShyneeCoordinates
    {
        public ShyneeCoordinates(
            double latitude, 
            double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }

        public double Longitude { get; }

        public double CalculateDistance(
            double latitudeToCompare,
            double longitudeToCompare)
        {
            var R = 6372.8; // In kilometers
            var dLat = ToRadians(latitudeToCompare - Latitude);
            var dLon = ToRadians(longitudeToCompare - Longitude);
            var lat1 = ToRadians(Latitude);
            var lat2 = ToRadians(latitudeToCompare);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return R * 2 * Math.Asin(Math.Sqrt(a));
        }

        private double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
