using Lerato.EmployeeAdmin.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Lerato.EmployeeAdmin.Converters
{
    public sealed class ContainerToIsSelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentSection = (Sections)value;

            var preferredSection = Enum.Parse(typeof(Sections), (string)parameter);

            return currentSection.Equals(preferredSection) ? Color.White : Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
