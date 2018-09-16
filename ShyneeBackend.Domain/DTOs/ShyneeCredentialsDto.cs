using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeCredentialsDto
    {
        public ShyneeCredentialsDto(
            Guid id,
            string email,
            string token)
        {
            Id = id;
            Email = email;
            Token = token;
        }

        public Guid Id { get; }

        public string Email { get; }

        public string Token { get; }
    }
}
