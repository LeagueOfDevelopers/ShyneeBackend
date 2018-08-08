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

        public string Email { get; }

        public string Password { get; }

        public bool HasGoogleAccount { get; }

        public bool HasFacebookAccount { get; }
    }
}
