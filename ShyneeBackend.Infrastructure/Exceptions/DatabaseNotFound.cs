using System;

namespace ShyneeBackend.Infrastructure.Exceptions
{
    public class DatabaseNotFound : ApplicationException
    {
        public DatabaseNotFound(string message = "Required database has not found")
        : base(message)
        {
        }

        public DatabaseNotFound(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
