using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Application.Filters;
using ShyneeBackend.Application.RequestModels;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IServices;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Threading.Tasks;

namespace ShyneeBackend.Application.Controllers
{
    [Produces("application/json")]
    [Route("shynees/{id:guid}")]
    public class ShyneeController : Controller
    {
        private readonly IShyneesService _shyneesService;

        public ShyneeController(
            IShyneesService shyneesService)
        {
            _shyneesService = shyneesService;
        }

        /// <summary>
        /// Returns shynee own profile data
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("profile")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileDto))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> GetShyneeProfile([FromRoute] Guid id)
        {
            var shyneeProfile = _shyneesService.GetShyneeProfile(id);
            return Ok(shyneeProfile);
        }

        [HttpPut]
        [Authorize]
        [Route("profile")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileDto))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        [ModelValidation]
        public async Task<IActionResult> UpdateShyneeProfile(
            [FromRoute] Guid id, 
            [FromBody] EditedShyneeProfile profile)
        {
            var shyneeProfile = _shyneesService.UpdateShyneeProfile(
                id, 
                new ShyneeProfile(
                    profile.Nickname,
                    profile.AvatarUri,
                    profile.Name,
                    profile.Dob,
                    profile.Gender,
                    profile.Interests,
                    profile.PersonalInfo));
            return Ok(shyneeProfile);
        }

        /// <summary>
        /// Returns shynee settings
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("settings")]
        [SwaggerResponse(200, Type = typeof(ShyneeSettings))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> GetShyneeSettingsForEdit([FromRoute] Guid id)
        {
            var shyneeSettings = _shyneesService.GetShyneeSettings(id);
            return Ok(shyneeSettings);
        }

        /// <summary>
        /// Updates shynee settings except I am ready status
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <param name="readySettings">Shynee ready settings except I am ready status</param>
        /// <returns>Shynee id and all settings including I am ready status</returns>
        [HttpPut]
        [Authorize]
        [Route("settings")]
        [SwaggerResponse(200, Type = typeof(ShyneeSettings))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        [ModelValidation]
        public async Task<IActionResult> UpdateShyneeSettings(
            [FromRoute] Guid id,
            [FromBody] EditedShyneeSettings readySettings)
        {
            var shyneeSettings = _shyneesService.UpdateShyneeSettings(
                id,
                new ShyneeSettings(
                    readySettings.BackgroundModeIsEnabled,
                    readySettings.MetroModeIsEnabled,
                    readySettings.PushNotificationsAreEnabled,
                    readySettings.OfferMetroModeActivationWhenNoCoonnectionIsEnabled,
                    readySettings.OfferMetroModeDeactivationWhenCoonnectionIsEnabled,
                    readySettings.PushNotificationOnNewAcquaintanceIsEnabled));
            return Ok(shyneeSettings);
        }

        /// <summary>
        /// Updates shynee ready status and returns updated value
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <param name="isReady">I am ready status</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route("ready/{isReady}")]
        [SwaggerResponse(200, Type = typeof(bool))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> UpdateReadySetting(
            [FromRoute] Guid id,
            [FromRoute] bool isReady)
        {
            var isShyneeReady = _shyneesService.ChangeShyneeReadySetting(id, isReady);
            return Ok(isShyneeReady);
        }
    }
}
