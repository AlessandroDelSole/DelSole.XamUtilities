using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DelSole.XamUtilities.Controls
{
    /// <summary>
    /// Provide a Picker view that supports data-binding to enumerations
    /// It also supports the <seealso cref="DisplayAttribute"/> attribute and the Description property
    /// from the <seealso cref="System.ComponentModel.DataAnnotations"/> namespace
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumBindablePicker<T> : Picker where T : struct
    {
        public EnumBindablePicker()
        {
            SelectedIndexChanged += OnSelectedIndexChanged;
            //Fill the Items from the enum
            foreach (var value in System.Enum.GetValues(typeof(T)))
            {
                Items.Add(GetEnumDescription(value));
            }
        }

        public static BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(T), typeof(EnumBindablePicker<T>), default(T), propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public T SelectedItem
        {
            get
            {
                return (T)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = default(T);
            }
            else
            {
                //try parsing, if using description this will fail
                T match;
                if (!System.Enum.TryParse<T>(Items[SelectedIndex], out match))
                {
                    //find enum by Description
                    match = GetEnumByDescription(Items[SelectedIndex]);
                }
                SelectedItem = (T)System.Enum.Parse(typeof(T), match.ToString());
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as EnumBindablePicker<T>;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(GetEnumDescription(newvalue));
            }
        }

        private static string GetEnumDescription(object value)
        {
            string result = value.ToString();
            DisplayAttribute attribute = typeof(T).GetRuntimeField(value.ToString()).
                GetCustomAttributes<DisplayAttribute>(false).SingleOrDefault();

            if (attribute != null)
                result = attribute.Description;

            return result;
        }

        private T GetEnumByDescription(string description)
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>().FirstOrDefault(x => string.Equals(GetEnumDescription(x), description));
        }
    }
}
