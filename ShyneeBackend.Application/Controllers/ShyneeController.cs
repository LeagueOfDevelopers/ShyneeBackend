using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Application.Filters;
using ShyneeBackend.Application.RequestModels;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
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
            var shyneeProfile = await _shyneesService.GetShyneeProfileAsync(id);
            return Ok(shyneeProfile);
        }

        /// <summary>
        /// Updates profile fields
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <param name="profile">Shynee profile fields</param>
        /// <returns></returns>
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
            var shyneeProfile = await _shyneesService.UpdateShyneeProfileAsync(
                id, 
                new ShyneeProfile(
                    profile.Nickname,
                    profile.Name,
                    profile.Dob,
                    profile.Gender,
                    profile.Interests,
                    profile.PersonalInfo));
            return Ok(shyneeProfile);
        }

        /// <summary>
        /// Returns profile field statuses: 
        /// true for visible, false for hidden or empty
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("profile/privacy")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileFieldsPrivacyDto))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(409, Type = typeof(NullParameterValueWhileStatusIsNotEmptyException))]
        [ModelValidation]
        public async Task<IActionResult> GetShyneeProfileFieldsPrivacy(
            [FromRoute] Guid id)
        {
            var shyneeProfileFieldsPrivacy = await _shyneesService.GetShyneeProfileFieldsPrivacyAsync(id);
            return Ok(shyneeProfileFieldsPrivacy);
        }

        /// <summary>
        /// Accepts fields privacy modificators and applies them
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <param name="fieldsPrivacy">Parameter privacy modificators</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route("profile/privacy")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileFieldsPrivacyDto))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(409, Type = typeof(NullParameterValueWhileStatusIsNotEmptyException))]
        [ModelValidation]
        public async Task<IActionResult> UpdateShyneeProfileFieldsPrivacy(
            [FromRoute] Guid id,
            [FromBody] ShyneeProfileFieldsPrivacy fieldsPrivacy)
        {
            var shyneeProfileFieldsPrivacy = await _shyneesService
                .UpdateShyneeProfileFieldsPrivacyAsync(
                    id,
                    new ShyneeProfileFieldsPrivacyDto(
                        fieldsPrivacy.Nickname,
                        fieldsPrivacy.AvatarUri,
                        fieldsPrivacy.Name,
                        fieldsPrivacy.Dob,
                        fieldsPrivacy.Gender,
                        fieldsPrivacy.Interests,
                        fieldsPrivacy.PersonalInfo));
            return Ok(shyneeProfileFieldsPrivacy);
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
            var shyneeSettings = await _shyneesService.GetShyneeSettingsAsync(id);
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
            var shyneeSettings = await _shyneesService.UpdateShyneeSettingsAsync(
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
        [SwaggerResponse(200, Type = typeof(ShyneeIsReadySettingDto))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> UpdateReadySetting(
            [FromRoute] Guid id,
            [FromRoute] bool isReady)
        {
            var isShyneeReady = await _shyneesService.ChangeShyneeReadySettingAsync(id, isReady);
            return Ok(isShyneeReady);
        }
    }
}
