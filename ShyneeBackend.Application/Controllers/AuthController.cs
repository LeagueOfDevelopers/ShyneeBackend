using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Application.Filters;
using ShyneeBackend.Application.Jwt;
using ShyneeBackend.Application.RequestModels;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
using ShyneeBackend.Application.Extensions;

namespace ShyneeBackend.Application.Controllers
{
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private readonly IShyneesService _shyneesService;
        private readonly IJwtIssuer _jwtIssuer;

        public AuthController(
            IShyneesService shyneesService,
            IJwtIssuer jwtIssuer)
        {
            _jwtIssuer = jwtIssuer;
            _shyneesService = shyneesService;
        }

        /// <summary>
        /// Sign up shynee
        /// </summary>
        /// <param name="shynee">credentials and profile data</param>
        /// <returns></returns>
        [HttpPost]
        [Route("shynees")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileWithCredentials))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(409, Type = typeof(CreateShynee))]
        [ModelValidation]
        public async Task<IActionResult> CreateShynee(
            [FromBody] CreateShynee shynee)
        {
            var shyneeCredentials = new ShyneeCredentials(
                shynee.Email, 
                Hasher.HashPassword(shynee.Password));
            var shyneeProfile = new Domain.Entities.ShyneeProfile(
                shynee.Nickname,
                shynee.AvatarUri,
                shynee.Name,
                shynee.Dob,
                shynee.Gender,
                shynee.Interests,
                shynee.PersonalInfo);
            var createdShynee = _shyneesService.CreateShynee(
                shyneeCredentials,
                shyneeProfile);
            var shyneeProfileWithCredentials = new ShyneeProfileWithCredentials(
                createdShynee.Id,
                createdShynee.Credentials.Email,
                _jwtIssuer.IssueJwt(createdShynee.Id),
                createdShynee.Profile);
            return Ok(shyneeProfileWithCredentials);
        }

        [Authorize]
        [HttpGet]
        [Route("refresh")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileWithCredentials))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public IActionResult RefreshToken()
        {
            var id = Request.GetUserId();
            var shynee = _shyneesService.GetShynee(id);
            var shyneeProfileWithCredentials = new ShyneeProfileWithCredentials(
                shynee.Id,
                shynee.Credentials.Email,
                _jwtIssuer.IssueJwt(shynee.Id),
                shynee.Profile);
            return Ok(shyneeProfileWithCredentials);
        }
    }
}
