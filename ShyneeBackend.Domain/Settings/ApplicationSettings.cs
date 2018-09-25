namespace ShyneeBackend.Domain.Settings
{
    public class ApplicationSettings
    {
        public ApplicationSettings(
            string defaultNickname, 
            double radiusAround,
            string uploadsFolderName)
        {
            DefaultNickname = defaultNickname;
            RadiusAround = radiusAround;
            UploadsFolderName = uploadsFolderName;
        }

        public string DefaultNickname { get; }

        public double RadiusAround { get; }

        public string UploadsFolderName { get; }
    }
}
