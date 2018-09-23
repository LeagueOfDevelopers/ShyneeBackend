using Microsoft.AspNetCore.Http;
using ShyneeBackend.Domain.DTOs;
using System;

namespace ShyneeBackend.Domain.IServices
{
    public interface IAssetsService
    {
        UploadedAssetPathDto UploadImage(
            Guid userId,
            string webRootPath, 
            IFormFile fileName);

        FileDto GetFile(string webRootPath, string name);
    }
}
