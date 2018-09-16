using System;

namespace ShyneeBackend.Domain.Entities
{
    public class Shynee
    {
        public Shynee(
            ShyneeCredentials credentials, 
            ShyneeCoordinates coordinates, 
            ShyneeProfile profile, 
            ShyneeSettings settings)
        {
            Id = Guid.NewGuid();
            Credentials = credentials;
            Coordinates = coordinates;
            Profile = profile;
            Settings = settings;
        }

        public Shynee(
            Guid id,
            ShyneeCredentials credentials,
            ShyneeCoordinates coordinates,
            ShyneeProfile profile,
            ShyneeSettings settings)
        {
            Id = id;
            Credentials = credentials;
            Coordinates = coordinates;
            Profile = profile;
            Settings = settings;
        }

        public Guid Id { get; private set; }

        public ShyneeCredentials Credentials { get; }

        public ShyneeCoordinates Coordinates { get; private set; }

        public ShyneeProfile Profile { get; private set; }

        public ShyneeSettings Settings { get; private set; }

        public void UpdateProfile(ShyneeProfile profile)
        {
            Profile = profile;
        }

        public void UpdateCoordinates(ShyneeCoordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public void UpdateSettings(ShyneeSettings settings)
        {
            Settings = settings;
        }
    }
}
