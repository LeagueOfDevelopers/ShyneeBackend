using System;

namespace ShyneeBackend.Domain.Exceptions
{
    public class ShyneeDuplicateException : ApplicationException
    {
        public ShyneeDuplicateException(string message = "Shynee already exists")
        : base(message)
        {
        }

        public ShyneeDuplicateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
