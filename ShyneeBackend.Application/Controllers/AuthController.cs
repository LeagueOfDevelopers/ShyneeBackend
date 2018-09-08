using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Application.Filters;
using ShyneeBackend.Application.RequestModels;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;

namespace ShyneeBackend.Application.Controllers
{
    [Produces("application/json")]
    [Route("shynees")]
    public class AuthController : Controller
    {
        private readonly IShyneesService _shyneesService;

        public AuthController(
            IShyneesService shyneesService)
        {
            _shyneesService = shyneesService;
        }

        /// <summary>
        /// Sign up shynee
        /// </summary>
        /// <param name="shynee">credentials and profile data</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
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
            var shyneeProfileWithCredentials = _shyneesService.CreateShynee(
                shyneeCredentials,
                shyneeProfile);
            return Ok(shyneeProfileWithCredentials);
        }
    }
}
