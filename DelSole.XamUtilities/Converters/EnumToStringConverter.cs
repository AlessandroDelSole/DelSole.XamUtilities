using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using System.ComponentModel.DataAnnotations;

namespace DelSole.XamUtilities.Converters
{
    /// <summary>
    /// Convert a value from an enumeration into a string, provided its <seealso cref="DisplayAttribute"/> attribute with the Description property
    /// </summary>
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            System.Enum converted = (System.Enum)value;
            string convertedString = GetDescription(converted);
            return convertedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        public static string GetDescription(System.Enum en)
        {
            Type type = en.GetType();
            string result = "";
            FieldInfo memInfo = type.GetRuntimeField(en.ToString());

            IEnumerable<DisplayAttribute> attrs = memInfo.GetCustomAttributes<DisplayAttribute>(false);

            var attribute = attrs.FirstOrDefault();

            if (attribute != null)
            {
                result = attribute.Description;
                return result;
            }
            else
            {
                return en.ToString();
            }
        }
    }
}
