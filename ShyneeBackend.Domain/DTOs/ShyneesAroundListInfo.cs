namespace ShyneeBackend.Domain.DTOs
{
    /// <summary>
    /// Shynee info for shynee around screen
    /// </summary>
    public class ShyneesAroundListInfo
    {
        public ShyneesAroundListInfo(
            uint id,
            string nickname)
        {
            Id = id;
            Nickname = nickname;
        }

        /// <summary>
        /// Shynee id
        /// </summary>
        public uint Id { get; }

        /// <summary>
        /// Shynee nickname
        /// </summary>
        public string Nickname { get; }
    }
}
