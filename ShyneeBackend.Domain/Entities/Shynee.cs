﻿using System;

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

        public Shynee(
            Guid id,
            ShyneeCredentials credentials,
            ShyneeCoordinates coordinates,
            ShyneeProfile profile,
            ShyneeReadySettings readySettings)
        {
            Id = id;
            Credentials = credentials;
            Coordinates = coordinates;
            Profile = profile;
            ReadySettings = readySettings;
        }

        public Guid Id { get; private set; }

        public ShyneeCredentials Credentials { get; }

        public ShyneeCoordinates Coordinates { get; private set; }

        public ShyneeProfile Profile { get; private set; }

        public ShyneeReadySettings ReadySettings { get; private set; }

        public void UpdateProfile(ShyneeProfile profile)
        {
            Profile = profile;
        }

        public void UpdateCoordinates(ShyneeCoordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public void UpdateReadySettings(ShyneeReadySettings readySettings)
        {
            ReadySettings = readySettings;
        }
    }
}
