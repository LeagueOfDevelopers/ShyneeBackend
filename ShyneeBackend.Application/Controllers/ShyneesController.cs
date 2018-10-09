using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Application.Extensions;
using ShyneeBackend.Application.RequestModels;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IServices;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;

namespace ShyneeBackend.Application.Controllers
{
    [Produces("application/json")]
    [Route("shynees")]
    public class ShyneesController : Controller
    {
        private readonly IShyneesService _shyneesService;

        public ShyneesController(
            IShyneesService shyneesService)
        {
            _shyneesService = shyneesService;
        }

        /// <summary>
        /// Return all shynees with enabled ready status
        /// within a radius of five hundred meters
        /// </summary>
        /// <param name="coordinates">Shynee current latitude and longitude</param>
        /// <returns>Shynees around list</returns>
        [HttpPut]
        [Route("around")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<ShyneeAroundDto>))]
        public async Task<IActionResult> GetShyneesAround(
            [FromBody] Coordinates coordinates)
        {
            var shyneeCoordinates = new ShyneeCoordinates(
                coordinates.Latitude, 
                coordinates.Longitude);
            var shyneesAroundList = await _shyneesService
                .GetShyneesAroundListAsync(shyneeCoordinates);
            if (Request.IsUserAuthorized())
            {
                var id = Request.GetUserId();
                shyneesAroundList = shyneesAroundList.Where(s => s.Id != id);
                await _shyneesService.UpdateShyneeCoordinatesAsync(
                    id, 
                    shyneeCoordinates);
            }
            return Ok(shyneesAroundList);
        }

        /// <summary>
        /// Returns Shynee profile public fields if requester is logged in
        /// </summary>
        /// <param name="id">Shynee guid id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfileDto))]
        [SwaggerResponse(404, Type = typeof(NotFoundResult))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> GetShynee([FromRoute] Guid id)
        {
            var shynee = await _shyneesService.GetShyneePublicDataAsync(id);
            return Ok(shynee);
        }
    }
}
