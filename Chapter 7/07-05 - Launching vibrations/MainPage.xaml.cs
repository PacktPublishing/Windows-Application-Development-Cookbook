/*
    Exemplary file for Chapter 7 - Built-in Sensors.
    Recipe: Launching vibrations.
*/

using System;
using Windows.Foundation.Metadata;
using Windows.Phone.Devices.Notification;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CH07
{
    public sealed partial class MainPage : Page
    {
        private VibrationDevice _vibration;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                _vibration = VibrationDevice.GetDefault();
            }
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (_vibration != null)
            {
                _vibration.Vibrate(TimeSpan.FromSeconds(1));
            }
        }
    }
}
