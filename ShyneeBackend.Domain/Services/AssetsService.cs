using Microsoft.AspNetCore.Http;
using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Domain.Settings;
using System;
using System.IO;

namespace ShyneeBackend.Domain.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly ApplicationSettings _applicationSettings;
        private readonly IShyneesService _shyneesService;

        public AssetsService(
            ApplicationSettings applicationSettings,
            IShyneesService shyneesService)
        {
            _applicationSettings = applicationSettings;
            _shyneesService = shyneesService;
        }

        public FileDto GetFile(
            string webRootPath, 
            string assetName)
        {
            var uploadPath = Path.Combine(
                webRootPath,
                _applicationSettings.UploadsFolderName);
            var assetPath = Path.Combine(uploadPath, assetName);
            if (!File.Exists(assetPath))
                throw new FileNotFoundException();
            var fileBytes = File.ReadAllBytes(assetPath);
            var extension = Path.GetExtension(assetName).Trim('.');
            var contentType = "image/" + extension;
            var file = new FileDto(fileBytes, contentType);
            return file;
        }

        public UploadedAssetPathDto UploadImage(
            Guid userId,
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
                file.CopyTo(filestream);
            }
    
            var avatarPath = _shyneesService.UpdateShyneeAvatar(userId, assetName);
            return avatarPath;
        }
    }
}
