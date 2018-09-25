namespace ShyneeBackend.Domain.DTOs
{
    public class FileDto
    {
        public FileDto(
            byte[] fileBytes, 
            string contentType)
        {
            FileBytes = fileBytes;
            ContentType = contentType;
        }

        public byte[] FileBytes { get; }
        public string ContentType { get; }
    }
}
