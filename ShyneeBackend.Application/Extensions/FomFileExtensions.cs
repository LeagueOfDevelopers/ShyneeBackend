using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShyneeBackend.Application.Extensions
{
    public static class FomFileExtensions
    {
        public static bool IsImageExtensionAllowed(this IFormFile file)
        {
            var allowedExtensions = new List<string>
            {
                ".jpg",
                ".jpeg",
                ".png"
            };

            var extension = Path.GetExtension(file.FileName.ToString());
            return allowedExtensions.Any(c => c.Equals(extension));
        }
    }
}
