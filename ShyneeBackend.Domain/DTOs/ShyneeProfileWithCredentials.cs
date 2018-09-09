using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeProfileWithCredentials
    {
        public ShyneeProfileWithCredentials(
            Guid id,
            string email,
            string token,
            Entities.ShyneeProfile profile)
        {
            Id = id;
            Email = email;
            Token = token;
            Profile = profile;
        }

        public Guid Id { get; }

        public string Email { get; }

        public string Token { get; }

        public Entities.ShyneeProfile Profile { get; }
    }
}
