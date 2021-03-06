﻿using System;

namespace ShyneeBackend.Domain.DTOs
{
    /// <summary>
    /// Shynee info for shynee around screen
    /// </summary>
    public class ShyneeAroundDto
    {
        public ShyneeAroundDto(
            Guid id,
            string nickname,
            string avatarUri)
        {
            Id = id;
            Nickname = nickname;
            AvatarUri = avatarUri;
        }

        public Guid Id { get; }

        public string Nickname { get; }

        public string AvatarUri { get; }
    }
}
