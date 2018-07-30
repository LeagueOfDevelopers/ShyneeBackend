namespace ShyneeBackend.Domain.Entities
{
    public class ShyneeCredentials
    {
        public ShyneeCredentials(
            string email, 
            string password, 
            bool hasGoogleAccount = false, 
            bool hasFacebookAccount = false)
        {
            Email = email;
            Password = password;
            HasGoogleAccount = hasGoogleAccount;
            HasFacebookAccount = hasFacebookAccount;
        }

        /// <summary>
        /// Shynee email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Shynee password
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Defines if shynee can authenticate with Google
        /// </summary>
        public bool HasGoogleAccount { get; }

        /// <summary>
        /// Defines if shynee can authenticate with Facebook
        /// </summary>
        public bool HasFacebookAccount { get; }
    }
}
