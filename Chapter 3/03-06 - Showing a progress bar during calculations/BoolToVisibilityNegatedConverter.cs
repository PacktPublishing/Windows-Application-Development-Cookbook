/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Showing a progress bar during calculations.
*/

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace CH03.Models
{
    public class BoolToVisibilityNegatedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (Visibility)value != Visibility.Visible;
        }
    }
}
