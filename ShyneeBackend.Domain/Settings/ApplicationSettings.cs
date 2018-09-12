using System;

namespace ShyneeBackend.Domain.Settings
{
    public class ApplicationSettings
    {
        public ApplicationSettings(
            string defaultNickname, 
            double radiusAround)
        {
            DefaultNickname = defaultNickname;
            RadiusAround = radiusAround;
        }

        public string DefaultNickname { get; }

        public double RadiusAround { get; }

    }
}
