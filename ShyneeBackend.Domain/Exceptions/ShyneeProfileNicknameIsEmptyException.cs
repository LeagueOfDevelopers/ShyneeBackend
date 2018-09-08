using System;

namespace ShyneeBackend.Domain.Exceptions
{
    public class ShyneeProfileNicknameIsEmptyException : ApplicationException
    {
        public ShyneeProfileNicknameIsEmptyException() : base()
        {
            
        }

        public ShyneeProfileNicknameIsEmptyException(string message)
        : base(message)
        {
        }

        public ShyneeProfileNicknameIsEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
