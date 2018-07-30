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

        /// <summary>
        /// shynee current latitude
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// shynee current longitude
        /// </summary>
        public double Longitude { get; }
    }
}
