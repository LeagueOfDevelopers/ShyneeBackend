using Microsoft.AspNetCore.Http;
using ShyneeBackend.Domain.DTOs;
using System.Threading.Tasks;

namespace ShyneeBackend.Domain.IServices
{
    public interface IAssetsService
    {
        Task<string> UploadImageAsync(
            string webRootPath, 
            IFormFile fileName);

        Task<FileDto> GetImageAsync(
            string webRootPath, 
            string name);
    }
}
    