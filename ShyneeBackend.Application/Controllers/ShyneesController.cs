using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
using ShyneeBackend.Domain.IServices;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShyneeBackend.Application.Controllers
{
    [Produces("application/json")]
    [Route("shynees/")]
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
        /// <param name="latitude">Shynee current latitude</param>
        /// <param name="longitude">Shynee current longitude</param>
        /// <returns>Shynees around list</returns>
        [HttpGet]
        [Route("around")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<ShyneesAroundList>))]
        public async Task<IActionResult> GetShyneesAround(
            [FromQuery(Name = "latitude")] double latitude,
            [FromQuery(Name = "longitude")] double longitude)
        {
            var shyneeCoordinates = new ShyneeCoordinates(latitude, longitude);
            var shyneesAroundList = _shyneesService
                .GetShyneesAroundList(shyneeCoordinates);
            return Ok(shyneesAroundList);
        }

        /// <summary>
        /// Returns Shynee profile public fields if requester is logged in
        /// </summary>
        /// <param name="id">Shynee guid id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerResponse(200, Type = typeof(ShyneeProfilePublicData))]
        [SwaggerResponse(404, Type = typeof(NotFoundResult))]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        public async Task<IActionResult> GetShynee([FromRoute] Guid id)
        {
            try
            {
                var shynee = _shyneesService.GetShyneePublicData(id);
                return Ok(shynee);
            }
            catch (ShyneeNotFoundException ex)
            {
                return NotFound();
            }
        }
    }
}
