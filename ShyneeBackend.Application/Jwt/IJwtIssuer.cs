using System;

namespace ShyneeBackend.Application.Jwt
{
    public interface IJwtIssuer
    {
        string IssueJwt(string role, Guid id);

        string IssueJwt(Guid id);
    }
}
