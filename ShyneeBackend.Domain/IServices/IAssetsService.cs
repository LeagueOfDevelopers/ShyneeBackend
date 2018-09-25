using Microsoft.AspNetCore.Http;
using ShyneeBackend.Domain.DTOs;
using System;

namespace ShyneeBackend.Domain.IServices
{
    public interface IAssetsService
    {
        string UploadImage(
            string webRootPath, 
            IFormFile fileName);

        FileDto GetImage(
            string webRootPath, 
            string name);
    }
}
