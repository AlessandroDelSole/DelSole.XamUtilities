using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DelSole.XamUtilities.Samples.BindingNullableDates
{
    public partial class DatePickerPage : ContentPage
    {
        private Employee Employee { get; set; }
        public DatePickerPage()
        {
            InitializeComponent();
            this.Employee = new Employee();
            this.BindingContext = this.Employee;
        }
    }
}
