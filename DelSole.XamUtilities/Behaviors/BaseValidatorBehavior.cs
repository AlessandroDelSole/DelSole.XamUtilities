using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DelSole.XamUtilities.Behaviors
{
    public class BaseValidatorBehavior<T> : Behavior<T>,
        IValidatorBehavior where T : BindableObject
    {
        static readonly BindablePropertyKey IsValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid", typeof(bool),
            typeof(BaseValidatorBehavior<T>), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            set { SetValue(IsValidPropertyKey, value); }
        }
    }
}
