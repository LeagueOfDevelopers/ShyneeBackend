using ShyneeBackend.Domain.Entities;
using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeSettings
    {
        public ShyneeSettings(
            Guid id, 
            ShyneeReadySettings readySettings)
        {
            Id = id;
            ReadySettings = readySettings;
        }

        public Guid Id { get; }

        public ShyneeReadySettings ReadySettings {get;}
    }
}
