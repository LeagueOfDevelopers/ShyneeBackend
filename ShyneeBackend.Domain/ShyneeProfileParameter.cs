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

        public ShyneeProfileParameterStatus Status { get; }

        public T Parameter { get; }
    }
}
