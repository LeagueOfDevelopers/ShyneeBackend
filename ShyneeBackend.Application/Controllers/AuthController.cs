using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Application.Extensions;
using ShyneeBackend.Application.Filters;
using ShyneeBackend.Application.Jwt;
using ShyneeBackend.Application.RequestModels;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;

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
        [SwaggerResponse(200, Type = typeof(ShyneeCredentialsDto))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(409, Type = typeof(CreateShynee))]
        [ModelValidation]
        public async Task<IActionResult> CreateShynee(
            [FromBody] CreateShynee shynee)
        {
            var shyneeCredentials = new ShyneeCredentials(
                shynee.Email, 
                Hasher.HashPassword(shynee.Password));
            var shyneeProfile = new ShyneeProfile(
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
            var shyneeProfileDto = new ShyneeProfileDto(
                shyneeProfile.Nickname.Parameter,
                shyneeProfile.AvatarUri.Parameter,
                shyneeProfile.Name.Parameter,
                shyneeProfile.Dob.Parameter,
                shyneeProfile.Gender.Parameter,
                shyneeProfile.Interests.Parameter,
                shyneeProfile.PersonalInfo.Parameter);
            var shyneeCredentialsDto = new ShyneeCredentialsDto(
                createdShynee.Id,
                createdShynee.Credentials.Email,
                _jwtIssuer.IssueJwt(createdShynee.Id),
                shyneeProfileDto);
            return Ok(shyneeCredentialsDto);
        }

        [Route("login")]
        [HttpPost]
        [SwaggerResponse(200, Type = typeof(ShyneeCredentialsDto))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(401, Type = typeof(InvalidPasswordException))]
        [SwaggerResponse(404, Type = typeof(ShyneeNotFoundException))]
        [SwaggerResponse(409, Type = typeof(CreateShynee))]
        [ModelValidation]
        public async Task<IActionResult> Login(
            [FromBody] LoginShynee loginShynee)
        {
            var shyneeCredentials = new ShyneeCredentials(
                loginShynee.Email,
                loginShynee.Password);
            var shynee = _shyneesService.FindShyneeByCredentials(shyneeCredentials);
            var shyneeProfile = shynee.Profile;
            var shyneeProfileDto = new ShyneeProfileDto(
                shyneeProfile.Nickname.Parameter,
                shyneeProfile.AvatarUri.Parameter,
                shyneeProfile.Name.Parameter,
                shyneeProfile.Dob.Parameter,
                shyneeProfile.Gender.Parameter,
                shyneeProfile.Interests.Parameter,
                shyneeProfile.PersonalInfo.Parameter);
            var shyneeCredentialsDto = new ShyneeCredentialsDto(
                shynee.Id,
                shynee.Credentials.Email,
                _jwtIssuer.IssueJwt(shynee.Id),
                shyneeProfileDto);
            return Ok(shyneeCredentialsDto);
        }

        [Authorize]
        [HttpGet]
        [Route("refresh")]
        [SwaggerResponse(200, Type = typeof(ShyneeCredentialsDto))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public IActionResult RefreshToken()
        {
            var id = Request.GetUserId();
            var shynee = _shyneesService.GetShynee(id);
            var shyneeProfile = shynee.Profile;
            var shyneeProfileDto = new ShyneeProfileDto(
                shyneeProfile.Nickname.Parameter,
                shyneeProfile.AvatarUri.Parameter,
                shyneeProfile.Name.Parameter,
                shyneeProfile.Dob.Parameter,
                shyneeProfile.Gender.Parameter,
                shyneeProfile.Interests.Parameter,
                shyneeProfile.PersonalInfo.Parameter);
            var shyneeCredentials = new ShyneeCredentialsDto(
                shynee.Id,
                shynee.Credentials.Email,
                _jwtIssuer.IssueJwt(shynee.Id),
                shyneeProfileDto);
            return Ok(shyneeCredentials);
        }
    }
}
