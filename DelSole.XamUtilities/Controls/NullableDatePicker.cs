using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DelSole.XamUtilities.Controls
{
    /// <summary>
    /// Provides a custom DatePicker that supports data-binding to DateTime? objects
    /// Usage: bind to <seealso cref="NullableDate"/> property instead of Date and format
    /// dates using <seealso cref="DateFormat"/> instead of Format
    /// </summary>
    public class NullableDatePicker : DatePicker
    {
        private string _format = null;
        public static readonly BindableProperty NullableDateProperty = BindableProperty.Create("NullableDate", 
            typeof(DateTime?), typeof(NullableDatePicker), null);
        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); UpdateDate(); }
        }

        public static readonly BindableProperty DateFormatProperty = BindableProperty.Create("DateFormat", 
            typeof(string), typeof(NullableDatePicker), 
                defaultValue: default(string),
                defaultBindingMode: BindingMode.OneWay,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (NullableDatePicker)bindable;
                    ctrl.DateFormat = (string)newValue;
                });

        public string DateFormat
        {
            get { return (string)GetValue(DateFormatProperty); }
            set { SetValue(DateFormatProperty, value); }
        }

        private void UpdateDate()
        {
            if (NullableDate.HasValue)
            {
                Format = DateFormat;
                Date = NullableDate.Value;
            }
            else
            {
                _format = Format;
                Format = "...";
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateDate();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Date")
                NullableDate = Date;
        }
    }
}
