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
        private readonly IShyneesService _shyneesService;

        public AssetsController(
            IHostingEnvironment environment,
            IAssetsService assetsService,
            IShyneesService shyneesService)
        {
            _hostingEnvironment = environment;
            _assetsService = assetsService;
            _shyneesService = shyneesService;
        }

        /// <summary>
        /// Accepts image(.jpg|.jpeg, .png formats) and returns image name
        /// </summary>
        /// <param name="image">Image to upload</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("img")]
        [RequestSizeLimit(20_000_000)]
        [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
        [SwaggerResponse(401, Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(415, Type = typeof(UnsupportedMediaTypeResult))]
        [SwaggerResponse(200, Type = typeof(UploadedAssetPathDto))]
        public async Task<IActionResult> UploadShyneeAvatar(IFormFile image)
        {
            var id = Request.GetUserId();
            if (!image.IsImageExtensionAllowed())
                return new UnsupportedMediaTypeResult();
            var uploadedImageName = _assetsService.UploadImage(
                _hostingEnvironment.WebRootPath,
                image);
            _shyneesService.UpdateShyneeAvatar(id, uploadedImageName);
            var uploadedAssetUri = new UploadedAssetPathDto(uploadedImageName);
            return Ok(uploadedAssetUri);
        }

        /// <summary>
        /// Returns image found by passed name
        /// </summary>
        /// <param name="name">Image name</param>
        /// <returns>Image in .jpg|.jpeg or .png formats</returns>
        [HttpGet]
        [SwaggerResponse(404, Type = typeof(FileNotFoundException))]
        [SwaggerResponse(200, Type = typeof(File))]
        [Route("img/{name}")]
        public async Task<IActionResult> GetImage([FromRoute] string name)
        {
            var image = _assetsService.GetImage(
                _hostingEnvironment.WebRootPath, 
                name);
            return File(image.FileBytes, image.ContentType);
        }
    }
}
