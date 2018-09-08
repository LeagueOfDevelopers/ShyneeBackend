using System;

namespace ShyneeBackend.Domain.Exceptions
{
    public class ShyneeNotFoundException : ApplicationException
    {
        public ShyneeNotFoundException(string message = "Shynee with required id does not exist")
        : base(message)
        {
        }

        public ShyneeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
