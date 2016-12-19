/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Adding a custom marker to a map.
*/

using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            GeolocationAccessStatus status = await Geolocator.RequestAccessAsync();
            if (status == GeolocationAccessStatus.Allowed)
            {
                Geolocator geolocator = new Geolocator();
                Geoposition position = await geolocator.GetGeopositionAsync();
                Map.Center = position.Coordinate.Point;
                Map.ZoomLevel = 15;

                Image marker = new Image();
                marker.Source = new BitmapImage(new Uri("ms-appx:///Assets/Marker.png", UriKind.Absolute));
                marker.Height = 64;
                Map.Children.Add(marker);
                MapControl.SetLocation(marker, position.Coordinate.Point);
                MapControl.SetNormalizedAnchorPoint(marker, new Point(0.5, 1.0));
            }
        }
    }
}
