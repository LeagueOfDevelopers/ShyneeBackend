using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Application.RequestModels;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
using ShyneeBackend.Domain.IServices;
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
        public async Task<IActionResult> CreateShynee(
            [FromBody] CreateShynee shynee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var shyneeCredentials = new ShyneeCredentials(shynee.Email, shynee.Password);
                var shyneeProfile = new Domain.Entities.ShyneeProfile(
                    shynee.Nickname,
                    shynee.AvatarUri,
                    shynee.Name,
                    shynee.Dob,
                    shynee.Gender,
                    shynee.Interests,
                    shynee.PersonalInfo);
                var createdShyneeId = _shyneesService.CreateShynee(
                    shyneeCredentials,
                    shyneeProfile);
                var createdShynee = _shyneesService.GetShynee(createdShyneeId);
                var shyneeProfileWithCredentials = new ShyneeProfileWithCredentials(
                    createdShynee.Id,
                    createdShynee.Credentials,
                    createdShynee.Profile);
                return Ok(shyneeProfileWithCredentials);
            }
            catch (ShyneeProfileNicknameIsEmptyException ex)
            {
                return BadRequest(ModelState);
            }
            catch (ShyneeDuplicateException ex)
            {
                return StatusCode(409, shynee);
            }
        }
    }
}
