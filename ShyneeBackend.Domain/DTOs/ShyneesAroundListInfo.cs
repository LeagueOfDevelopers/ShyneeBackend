using System;

namespace ShyneeBackend.Domain.DTOs
{
    /// <summary>
    /// Shynee info for shynee around screen
    /// </summary>
    public class ShyneesAroundListInfo
    {
        public ShyneesAroundListInfo(
            Guid id,
            string nickname,
            string avatarUri)
        {
            Id = id;
            Nickname = nickname;
            AvatarUri = avatarUri;
        }

        /// <summary>
        /// Shynee id
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Shynee nickname
        /// </summary>
        public string Nickname { get; }

        /// <summary>
        /// Shynee avatar uri
        /// </summary>
        public string AvatarUri { get; }
    }
}
