using System;

namespace ShyneeBackend.Domain.Exceptions
{
    public class ShyneeNotFoundException : ApplicationException
    {
        public ShyneeNotFoundException() : base()
        {
        }

        public ShyneeNotFoundException(string message)
        : base(message)
        {
        }

        public ShyneeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
