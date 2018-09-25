using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class UploadedAssetPathDto
    {
        public UploadedAssetPathDto(
            string assetName)
        {
            AssetName = assetName;
        }

        public string AssetName { get; }
    }
}
