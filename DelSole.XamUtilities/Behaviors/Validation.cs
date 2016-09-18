using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelSole.XamUtilities.Behaviors
{
    /// <summary>
    /// Store a list of validation errors
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// A list of validation errors. Key of type object is typically the View
        /// while Value of type string is an error message
        /// </summary>
        public static Dictionary<object, string> ValidationErrors { get; set; }
    }
}
