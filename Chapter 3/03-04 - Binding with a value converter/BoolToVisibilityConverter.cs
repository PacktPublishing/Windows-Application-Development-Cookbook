/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding with a value converter.
*/

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace CH03.Models
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
