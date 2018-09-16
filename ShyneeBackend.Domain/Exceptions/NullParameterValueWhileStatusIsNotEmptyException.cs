using System;

namespace ShyneeBackend.Domain.Exceptions
{
    public class NullParameterValueWhileStatusIsNotEmptyException : ApplicationException
    {
        public NullParameterValueWhileStatusIsNotEmptyException(
            string message = "Passed null parameter while shynee profile parameter status is not empty")
                : base(message)
        {
        }

        public NullParameterValueWhileStatusIsNotEmptyException(
            string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
