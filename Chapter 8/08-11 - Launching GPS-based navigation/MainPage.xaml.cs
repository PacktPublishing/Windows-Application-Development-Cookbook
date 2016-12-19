/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Launching GPS-based navigation.
*/

using System;
using System.Globalization;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            float latitude;
            float longitude;
            string latitudeString = TxtLatitude.Text.Replace(",", ".");
            string longitudeString = TxtLongitude.Text.Replace(",", ".");
            if (float.TryParse(latitudeString, NumberStyles.Float, new NumberFormatInfo(), out latitude)
                && float.TryParse(longitudeString, NumberStyles.Float, new NumberFormatInfo(), out longitude))
            {
                string uri = string.Format(
                    "ms-drive-to:?destination.latitude={0}&destination.longitude={1}&destination.name={2}",
                    latitude.ToString(new NumberFormatInfo()),
                    longitude.ToString(new NumberFormatInfo()),
                    "Destination for navigation");
                await Launcher.LaunchUriAsync(new Uri(uri));
            }
        }
    }
}
