using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DelSole.XamUtilities.Samples
{
    public enum RolesEnum
    {
        [Display(Description = "Employee")]
        Employee,
        [Display(Description = "Director or senior director")]
        Director,
        [Display(Description = "Corporate Vice President")]
        VicePresident,
        [Display(Description = "Chief Executive Officer")]
        CEO
    }
}
