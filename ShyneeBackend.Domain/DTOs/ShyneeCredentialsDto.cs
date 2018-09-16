using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeCredentialsDto
    {
        public ShyneeCredentialsDto(
            Guid id,
            string email,
            string token,
            ShyneeProfileDto profile)
        {
            Id = id;
            Email = email;
            Token = token;
            Profile = profile;
        }

        public Guid Id { get; }

        public string Email { get; }

        public string Token { get; }

        public ShyneeProfileDto Profile { get; }
    }
}
