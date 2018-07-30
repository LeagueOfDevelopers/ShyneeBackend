using System;
using System.Collections.Generic;
using System.Text;

namespace ShyneeBackend.Domain
{
    /// <summary>
    /// Describes status parameter
    /// </summary>
    public enum ShyneeProfileParameterStatusType
    {
        /// <summary>
        /// if was not mentioned
        /// </summary>
        Empty,
        /// <summary>
        /// if shynee keeps parameter private
        /// </summary>
        Hidden,
        /// <summary>
        /// if shynee keeps parameter public
        /// </summary>
        Visible
    }
}
