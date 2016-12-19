/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Choosing date and time.
*/

using System;
using Windows.UI.Xaml.Controls;

namespace CH02
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalendarDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            DateTimeOffset? offset = sender.Date;
            if (offset.HasValue)
            {
                DateTime selectedDate = offset.Value.Date;
            }
        }
    }
}
