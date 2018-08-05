namespace ShyneeBackend.Domain
{
    public class ShyneeProfileParameter
    {
        public ShyneeProfileParameter(
            ShyneeProfileParameterStatus status = ShyneeProfileParameterStatus.Empty, 
            string parameter = "")
        {
            Status = status;
            Parameter = parameter;
        }

        public ShyneeProfileParameterStatus Status { get; }

        public string Parameter { get; }
    }
}
