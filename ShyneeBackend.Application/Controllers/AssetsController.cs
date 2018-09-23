using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShyneeBackend.Application.Extensions;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.IServices;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Threading.Tasks;

namespace ShyneeBackend.Application.Controllers
{
    [Produces("application/json")]
    public class AssetsController : Controller
    {
        private readonly IAssetsService _assetsService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AssetsController(
            IHostingEnvironment environment,
            IAssetsService assetsService)
        {
            _hostingEnvironment = environment;
            _assetsService = assetsService;
        }

        /// <summary>
        /// Accepts file and returns uri if success
        /// </summary>
        /// <param name="file">File to upload</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("img")]
        [RequestSizeLimit(20_000_000)]
        [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(415, Type = typeof(UnsupportedMediaTypeResult))]
        [SwaggerResponse(200, Type = typeof(UploadedAssetPathDto))]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var id = Request.GetUserId();
            if (!file.IsImageExtensionAllowed())
                return new UnsupportedMediaTypeResult();
            var uploadedAssetUri = _assetsService.UploadImage(
                id,
                _hostingEnvironment.WebRootPath,
                file);
            return Ok(uploadedAssetUri);
        }

        /// <summary>
        /// Returns image if it is located by passed path
        /// </summary>
        /// <param name="path">Avatar uri field in Shynee profile</param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(404, Type = typeof(FileNotFoundException))]
        [SwaggerResponse(200, Type = typeof(File))]
        [Route("img/{name}")]
        public async Task<IActionResult> GetImage([FromRoute] string name)
        {
            var file = _assetsService.GetFile(
                _hostingEnvironment.WebRootPath, 
                name);
            return File(file.FileBytes, file.ContentType);
        }
    }
}
