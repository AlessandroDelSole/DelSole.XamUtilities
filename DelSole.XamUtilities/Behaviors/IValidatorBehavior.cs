using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelSole.XamUtilities.Behaviors
{
    /// <summary>
    /// Define a property that all validator behaviors must expose for validation to be considered passed
    /// </summary>
    public interface IValidatorBehavior
    {
        bool IsValid { get; set; }
    }
}
