/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Using value converters with parameters.
*/

using System;
using Windows.UI.Xaml.Data;

namespace CH03.Models
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string colorsString = (string)parameter;
            string[] colors = colorsString.Split(
                new char[] { '|' },
                StringSplitOptions.RemoveEmptyEntries);
            return (bool)value ? colors[0] : colors[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
