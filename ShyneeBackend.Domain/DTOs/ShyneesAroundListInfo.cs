namespace ShyneeBackend.Domain.DTOs
{
    /// <summary>
    /// Shynee info for shynee around screen
    /// </summary>
    public class ShyneesAroundListInfo
    {
        public ShyneesAroundListInfo(string nickname)
        {
            Nickname = nickname;
        }

        /// <summary>
        /// Shynee nickname
        /// </summary>
        public string Nickname { get; }
    }
}
