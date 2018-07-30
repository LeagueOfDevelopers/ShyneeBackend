using System;

namespace ShyneeBackend.Domain.Entities
{
    public class Shynee
    {
        public Shynee(
            ShyneeCredentials credentials, 
            ShyneeCoordinates coordinates, 
            ShyneeProfile profile, 
            ShyneeReadySettings readySettings)
        {
            Id = Guid.NewGuid();
            Credentials = credentials;
            Coordinates = coordinates;
            Profile = profile;
            ReadySettings = readySettings;
        }

        // Auto generated id
        public Guid Id { get; private set; }

        /// <summary>
        /// Shynee credentials
        /// </summary>
        public ShyneeCredentials Credentials { get; }

        /// <summary>
        /// Shynee coordinates
        /// </summary>
        public ShyneeCoordinates Coordinates { get; }

        /// <summary>
        /// Shynee profile fields
        /// </summary>
        public ShyneeProfile Profile { get; }

        /// <summary>
        /// Shynee ready settings
        /// </summary>
        public ShyneeReadySettings ReadySettings { get; }
    }
}
