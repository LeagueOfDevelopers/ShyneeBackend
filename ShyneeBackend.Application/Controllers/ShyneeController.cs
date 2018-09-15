﻿using Microsoft.AspNetCore.Mvc;
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
        [Route("profile")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileInfo))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> GetShyneeProfile([FromRoute] Guid id)
        {
            var shyneeProfile = _shyneesService.GetShyneeProfile(id);
            return Ok(shyneeProfile);
        }

        [HttpPost]
        [Route("profile")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileInfo))]
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
        [Route("settings")]
        [SwaggerResponse(200, Type = typeof(ShyneeSettings))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> GetShyneeSettingsForEdit([FromRoute] Guid id)
        {
            var shynee = _shyneesService.GetShyneeReadySettings(id);
            var shyneeSettings = new ShyneeSettings(
                id,
                shynee);
            return Ok(shyneeSettings);
        }

        /// <summary>
        /// Updates shynee settings except I am ready status
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <param name="readySettings">Shynee ready settings except I am ready status</param>
        /// <returns>Shynee id and all settings including I am ready status</returns>
        [HttpPost]
        [Route("settings")]
        [SwaggerResponse(200, Type = typeof(ShyneeSettings))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        [ModelValidation]
        public async Task<IActionResult> UpdateShyneeSettings(
            [FromRoute] Guid id,
            [FromBody] EditedShyneeReadySettings readySettings)
        {
            var shyneeReadySettings = _shyneesService.UpdateShyneeSettings(
                id,
                new ShyneeReadySettings(
                    readySettings.BackgroundModeIsEnabled,
                    readySettings.MetroModeIsEnabled,
                    readySettings.PushNotificationsAreEnabled,
                    readySettings.OfferMetroModeActivationWhenNoCoonnectionIsEnabled,
                    readySettings.OfferMetroModeDeactivationWhenCoonnectionIsEnabled,
                    readySettings.PushNotificationOnNewAcquaintanceIsEnabled));
            return Ok(shyneeReadySettings);
        }

        /// <summary>
        /// Updates shynee ready status and returns updated value
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <param name="isReady">I am ready status</param>
        /// <returns></returns>
        [HttpPost]
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
