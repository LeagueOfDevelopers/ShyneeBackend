using Microsoft.AspNetCore.Http;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Domain.Settings;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ShyneeBackend.Domain.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly ApplicationSettings _applicationSettings;
        private readonly IShyneesService _shyneesService;

        public AssetsService(
            ApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public async Task<FileDto> GetImageAsync(
            string webRootPath, 
            string assetName)
        {
            var uploadPath = Path.Combine(
                webRootPath,
                _applicationSettings.UploadsFolderName);
            var assetPath = Path.Combine(uploadPath, assetName);
            if (!File.Exists(assetPath))
                throw new FileNotFoundException();
            byte[] fileBytes;
            using (FileStream SourceStream = File.Open(
                assetPath, 
                FileMode.Open))
            {
                fileBytes = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(
                    fileBytes, 
                    0, 
                    (int)SourceStream.Length);
            }
            var extension = Path.GetExtension(assetName).Trim('.');
            var contentType = "image/" + extension;
            var file = new FileDto(fileBytes, contentType);
            return file;
        }

        public async Task<string> UploadImageAsync(
            string webRootPath, 
            IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var assetName = Guid.NewGuid() + extension;
            var uploadPath = Path.Combine(
                webRootPath, 
                _applicationSettings.UploadsFolderName);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            var assetPath = Path.Combine(uploadPath, assetName);
            using (var filestream = new FileStream(
                assetPath, 
                FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }
            return assetName;
        }
    }
}
