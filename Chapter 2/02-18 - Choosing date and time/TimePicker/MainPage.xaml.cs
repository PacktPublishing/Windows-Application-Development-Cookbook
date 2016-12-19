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

        private void TimePicker_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            TimeSpan selectedTime = e.NewTime;
        }
    }
}
