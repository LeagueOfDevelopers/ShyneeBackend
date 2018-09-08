using System;

namespace ShyneeBackend.Domain.Exceptions
{
    public class ShyneeDuplicateException : ApplicationException
    {
        public ShyneeDuplicateException() : base()
        {
        }

        public ShyneeDuplicateException(string message)
        : base(message)
        {
        }

        public ShyneeDuplicateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
