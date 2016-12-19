/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Showing a map within a page.
*/

using System;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BasicGeoposition center = new BasicGeoposition()
            {
                Latitude = 50.0406,
                Longitude = 21.9995
            };
            Map.Center = new Geopoint(center);
            Map.ZoomLevel = 15;
            Map.ColorScheme = MapColorScheme.Light;
            Map.Heading = 0;
            Map.BusinessLandmarksVisible = true;
            Map.LandmarksVisible = true;
            Map.PedestrianFeaturesVisible = true;
            Map.TrafficFlowVisible = true;
            Map.TransitFeaturesVisible = true;
        }

        private async void BtnShowCastle_Click(object sender, RoutedEventArgs e)
        {
            BasicGeoposition center = new BasicGeoposition()
            {
                Latitude = 50.0325,
                Longitude = 22.0007
            };
            await Map.TrySetViewAsync(new Geopoint(center));
        }

        private async void BtnShowAirport_Click(object sender, RoutedEventArgs e)
        {
            GeoboundingBox bounds = new GeoboundingBox(
                new BasicGeoposition()
                {
                    Latitude = 50.1146,
                    Longitude = 22.0015
                },
                new BasicGeoposition()
                {
                    Latitude = 50.1092,
                    Longitude = 22.0463
                });
            await Map.TrySetViewBoundsAsync(bounds, null, MapAnimationKind.Default);
        }
    }
}
