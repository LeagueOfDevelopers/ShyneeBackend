using System;
using System.Collections.Generic;
using System.Text;

namespace ShyneeBackend.Domain
{
    public class ShyneeProfileParameter
    {
        public ShyneeProfileParameter(
            ShyneeProfileParameterStatusType status = ShyneeProfileParameterStatusType.Empty, 
            string parameter = "")
        {
            Status = status;
            Parameter = parameter;
        }

        /// <summary>
        /// Defines shynee profile parameter status: 
        /// hidden, visible or empty
        /// </summary>
        public ShyneeProfileParameterStatusType Status { get; }

        /// <summary>
        /// Defines parameter value
        /// </summary>
        public string Parameter { get; }
    }
}
