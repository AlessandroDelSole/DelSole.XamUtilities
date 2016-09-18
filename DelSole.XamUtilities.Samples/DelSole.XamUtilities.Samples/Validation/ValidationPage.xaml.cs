using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DelSole.XamUtilities.Samples.Validation
{
    public partial class ValidationPage : ContentPage
    {
        private Employee Employee { get; set; }
        public ValidationPage()
        {
            InitializeComponent();

            this.Employee = new Employee();
            this.BindingContext = this.Employee;
        }
    }
}
