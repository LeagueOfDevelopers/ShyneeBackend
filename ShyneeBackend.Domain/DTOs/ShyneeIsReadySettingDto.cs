namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeIsReadySettingDto
    {
        public ShyneeIsReadySettingDto(bool isReady)
        {
            IsReady = isReady;
        }

        public bool IsReady { get; }
    }
}
