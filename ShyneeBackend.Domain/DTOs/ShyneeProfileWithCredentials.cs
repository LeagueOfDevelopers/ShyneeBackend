using ShyneeBackend.Domain.Entities;
using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeProfileWithCredentials
    {
        public ShyneeProfileWithCredentials(
            Guid id,
            ShyneeCredentials credentials,
            Entities.ShyneeProfile profile)
        {
            Id = id;
            Credentials = credentials;
            Profile = profile;
        }

        public Guid Id { get; }

        ShyneeCredentials Credentials { get; }

        Entities.ShyneeProfile Profile { get; }
    }
}
