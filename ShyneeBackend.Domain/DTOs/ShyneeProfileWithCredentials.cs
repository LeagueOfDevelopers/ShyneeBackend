using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeProfileWithCredentials
    {
        public ShyneeProfileWithCredentials(
            Guid id,
            string email,
            Entities.ShyneeProfile profile)
        {
            Id = id;
            Email = email;
            Profile = profile;
        }

        public Guid Id { get; }

        public string Email { get; }

        public Entities.ShyneeProfile Profile { get; }
    }
}
