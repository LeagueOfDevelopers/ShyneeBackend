using System;

namespace ShyneeBackend.Domain.Exceptions
{
    public class InvalidPasswordException : ApplicationException
    {
        public InvalidPasswordException(string message = "Shynee already exists")
        : base(message)
        {
        }

        public InvalidPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
