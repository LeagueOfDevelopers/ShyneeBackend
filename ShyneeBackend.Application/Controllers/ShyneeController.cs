﻿using Microsoft.AspNetCore.Mvc;
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
        [SwaggerResponse(200, Type = typeof(ShyneeProfileForEdit))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> GetShyneeProfileForEdit([FromRoute] Guid id)
        {
            var shyneeProfileForEdit = _shyneesService.GetShyneeProfileForEdit(id);
            return Ok(shyneeProfileForEdit);
        }

        [HttpPost]
        [Route("profile")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileForEdit))]
        [SwaggerResponse(400, Type = typeof(BadRequestObjectResult))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> UpdateShyneeProfile(
            [FromRoute] Guid id, 
            [FromBody] EditedShyneeProfile profile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var shyneeProfileForEdit = _shyneesService.UpdateShyneeProfile(
                id, 
                new ShyneeProfile(
                    profile.Nickname,
                    profile.AvatarUri,
                    profile.Name,
                    profile.Dob,
                    profile.Gender,
                    profile.Interests,
                    profile.PersonalInfo));
            return Ok(shyneeProfileForEdit);
        }

        /// <summary>
        /// Returns shynee settings
        /// </summary>
        /// <param name="id">Shynee id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("settings")]
        [SwaggerResponse(200, Type = typeof(ShyneeReadySettings))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> GetShyneeSettingsForEdit([FromRoute] Guid id)
        {
            var shynee = _shyneesService.GetShyneeReadySettings(id);
            return Ok(shynee);
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