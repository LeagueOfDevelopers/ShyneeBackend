using System;

namespace ShyneeBackend.Domain.Exceptions
{
    public class ShyneeProfileNicknameIsEmptyException : ApplicationException
    {
        public ShyneeProfileNicknameIsEmptyException(string message = "Shynee nickname can not be blank")
        : base(message)
        {
        }

        public ShyneeProfileNicknameIsEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
