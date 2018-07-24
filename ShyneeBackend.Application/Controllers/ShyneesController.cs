using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.IServices;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

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
        [SwaggerResponse(200, Type = typeof(IEnumerable<ShyneesAroundListInfo>))]
        public IActionResult GetShyneesAround(
            [FromQuery(Name = "latitude")] double latitude,
            [FromQuery(Name = "longitude")] double longitude)
        {
            var shyneesAroundList = _shyneesService
                .GetShyneesAroundList(latitude, longitude);
            return Ok(shyneesAroundList);
        }
    }
}
