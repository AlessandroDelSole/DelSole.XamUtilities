using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DelSole.XamUtilities.Samples.BindingEnums
{
    public partial class BindingEnumPage : ContentPage
    {
        private Employee Employee { get; set; }
        public BindingEnumPage()
        {
            InitializeComponent();

            this.Employee = new Employee();
            this.BindingContext = this.Employee;
        }
    }
}
