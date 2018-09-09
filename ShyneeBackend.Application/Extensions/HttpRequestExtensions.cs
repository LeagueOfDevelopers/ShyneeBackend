using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ShyneeBackend.Application.Extensions
{
    public static class HttpRequestExtensions
    {
        public static Guid GetUserId(this HttpRequest request)
        {
            var auth = request.Headers["Authorization"].ToString();
            var handler = new JwtSecurityTokenHandler();
            var id = Guid.Parse(handler.ReadJwtToken(auth.Substring(7)).Claims.First(c => c.Type == "UserId").Value);
            return id;
        }
    }
}
