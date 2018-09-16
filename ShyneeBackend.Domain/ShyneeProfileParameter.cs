using ShyneeBackend.Domain.Exceptions;

namespace ShyneeBackend.Domain
{
    public class ShyneeProfileParameter<T>
    {
        public ShyneeProfileParameter(
            ShyneeProfileParameterStatus status = ShyneeProfileParameterStatus.Empty, 
            T parameter = default(T))
        {
            Status = status;
            Parameter = parameter;
        }

        public ShyneeProfileParameter(
            bool statusIsVisible,
            T parameter)
        {
            Status = statusIsVisible ? 
                parameter == null ? 
                    throw new NullParameterValueWhileStatusIsNotEmptyException() :
                    ShyneeProfileParameterStatus.Visible :
                ShyneeProfileParameterStatus.Hidden;

            Parameter = parameter;
        }

        public ShyneeProfileParameterStatus Status { get; }

        public T Parameter { get; }
    }
}
